﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCon : MonoBehaviour { //アタッチはArmature、アニメーション時にArmatureが動くというバグがある。
	// publicの理由はButtonBace.csでこのスクリプトが使われるから。
	//プレイヤ動作
	public Rigidbody RB;
	public float maxspeed;
	public float jumpinterval;
	public bool OnPose; //ポーズ中
	//コントローラ
	private Vector3 CenterPos; //移動ボタンの中心
	private Vector3 Direction; //動く方向
	private GameObject ControllIn;
	private bool touch; //タッチ中か
	private Vector3 ControllInDir; //丸のUI中心からの相対位置
	private float xzmagnitude{
		get{
			return Mathf.Sqrt(Mathf.Pow (this.RB.velocity.x, 2f) + Mathf.Pow (this.RB.velocity.z, 2f));
		}
	}

	private Animator animator;

	//シーン遷移用
	public GameDirector GameDirectorScript; //ポーズからメニューに戻るとき使ってる！
	private Vector3 InitPos; //とまとの初期位置

	//クリア処理
	private float clearinterval; //クリアしてから少し時間が経ってからシーン遷移するため。
	private bool clear;
	private GameObject ClearText; //Textじゃないので注意

	// Use this for initialization
	void Start () {
		this.RB = GetComponent<Rigidbody> ();
		this.animator = transform.root.gameObject.GetComponent<Animator> (); //tomatochick
		this.maxspeed = 10.0f;
		this.jumpinterval = 0f;

		this.OnPose = false;

		this.CenterPos = new Vector3 (150f, 150f, 0f);
		this.Direction = Vector3.zero;
		this.ControllIn = GameObject.Find ("OverlayCanvas/ControllIn");
		this.touch = false;

		this.clearinterval = 0f;
		this.clear = false;
		this.ClearText = GameObject.Find ("OverlayCanvas/ClearText");
		this.ClearText.SetActive (false);

		this.GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();//Scene01から実行するとエラー

		switch(GameDirectorScript.StageNumber){ //Playerの初期位置設定
		case 1:
			this.InitPos = new Vector3(0f,30f,0f);
			break;
		case 2:
			this.InitPos = new Vector3(0f,30f,-180f);
			break;
		case 3:
			this.InitPos = new Vector3(0f,30f,-330f);
			break;
		case 4:
			this.InitPos = new Vector3(0f,30f,-490f);
			break;
		case 5:
			this.InitPos = new Vector3 (0f, 30f, -645f);
			break;
		case 6:
			this.InitPos = new Vector3 (0f, 30f, -795f);
			break;
		case 7:
			this.InitPos = new Vector3 (0f, 30f, -920f);
			break;
		default:
			break;
		}
		transform.position = this.InitPos;
	}
	
	// Update is called once per frame
	void Update () {
		if(!OnPose){ //ポーズ中でなければ、
		jumpinterval += Time.deltaTime; //s ???
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer) { //あいぽん
			
		} else { //パソコンだけ（デバッグ用）
			if (Input.GetKey (KeyCode.RightArrow)) { //右
				if (this.RB.velocity.z > -maxspeed) {
					this.RB.AddForce (Vector3.back * 100);
				}
			}
			if (Input.GetKey (KeyCode.LeftArrow)) { //左
				if (this.RB.velocity.z < maxspeed) {
					this.RB.AddForce (Vector3.forward * 100);
				}
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (this.RB.velocity.x < maxspeed) {
					this.RB.AddForce (Vector3.right * 100);
				}
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				if (this.RB.velocity.x > -maxspeed) {
					this.RB.AddForce (Vector3.left * 100);
				}
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (this.jumpinterval > 2f) {
					this.RB.AddForce (Vector3.up * 500);
					this.jumpinterval = 0f;
				}
			}

			move_editor ();
		}// else

		//アニメーション処理
		if(Mathf.Abs(this.RB.velocity.y) > 0.5f){
			this.animator.SetInteger("Fly", 1); //Animationのほう
			this.animator.speed = 3.0f; //飛んでるモーションは速い方が可愛い。
		}else{
			this.animator.SetInteger("Fly", 0);
			this.animator.speed = 1.0f;
		}

		if (this.clear) { //クリア後
			if(this.GameDirectorScript.ClearNumber < this.GameDirectorScript.StageNumber){
			this.GameDirectorScript.ClearNumber = this.GameDirectorScript.StageNumber;//クリアナンバーの更新
				PlayerPrefs.SetInt("ClearNumber" , this.GameDirectorScript.ClearNumber);//データ自動保存
			}
			this.clearinterval += Time.deltaTime;
			this.ClearText.SetActive (true);
		} 
		if (clearinterval > 1f) {//この前にリロードされるのはバグ？？？だから早め。
			this.GameDirectorScript.StageNumber = 0;//一応の初期化。いらないかも。このオブジェクトはシーン遷移で破壊されないので初期化が厄介？
			SceneManager.LoadScene ("MenuScene"); //ここが最後
		}


	}//update
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Finish") {
			/*Debug.Log ("Clear");*/
			other.gameObject.SetActive (false); //花がなくなる。
			this.clear = true;
		}
	}

	private void move_editor(){ //ここが移動の全て
		if (Input.GetMouseButtonDown (0)) {
			if (Vector3.Distance (Input.mousePosition, this.CenterPos) < 150f) {
				this.touch = true; //円のなかでタッチを開始したらon
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			this.touch = false; //どこででもタッチを離したらoff
		}

		if (this.touch) { //タッチ中
			if (Vector3.Distance (Input.mousePosition, this.CenterPos) < 150f) { //-x->z,+y->x、円形の中の場合
				this.ControllIn.GetComponent<RectTransform> ().anchoredPosition = Input.mousePosition;
				this.Direction.z = this.CenterPos.x - Input.mousePosition.x;
				this.Direction.x = Input.mousePosition.y - this.CenterPos.y;
				add_force (); //実際の動かしメソッド
			} else if (Input.mousePosition.x < 600f) { //タッチ中、円から指が外れた場合。これだとジャンプした時にelseに通っちゃう。ほんとはちゃんとやるべき。
				this.ControllInDir = Input.mousePosition - this.CenterPos; //方向ベクトル
				this.ControllInDir /= Vector3.Distance (Input.mousePosition, this.CenterPos);//正規化
				this.ControllInDir *= 150f; //150かける（サイズの問題）
				this.ControllIn.GetComponent<RectTransform> ().anchoredPosition = this.CenterPos + this.ControllInDir;//表示位置
				this.Direction.z = -this.ControllInDir.x; //3D変換
				this.Direction.x = this.ControllInDir.y;
				add_force ();
			} else {//ジャンプした時->ControllInの位置は何も書かなければ変わらない。addforceはされない。
			}
		} else { //タッチが離れたら丸が元の位置に戻る。
			this.ControllIn.GetComponent<RectTransform> ().anchoredPosition3D = new Vector3 (150f, 150f, 0f);
		}
	}//move/editor

	private void add_force(){ //一つ問題なのはy次元の速さも考慮してしまうこと。だけどそういうことでいいと思う
		if (xzmagnitude < maxspeed) { //yを考慮しない。
			this.RB.AddForce (Direction);
		} else {
			if (Vector3.Dot (this.Direction, this.RB.velocity) < 600f) { //緩め、3次元内積の計算。適当だけど前より動く。そもそもはやくてもいみない？
				this.RB.AddForce (Direction);
			}
		}
	}//add_force

}
