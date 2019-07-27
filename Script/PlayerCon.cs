using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour { //アタッチはArmature、アニメーション時にArmatureが動くというバグがある。
	// publicの理由はButtonBace.csでこのスクリプトが使われるから。
	public Rigidbody RB;
	public float maxspeed;
	public float jumpinterval;

	private Animator animator;

	private GameDirector GameDirectorScript;
	private Vector3 InitPos; //とまとの初期位置
	// Use this for initialization
	void Start () {
		this.RB = GetComponent<Rigidbody> ();
		this.animator = transform.root.gameObject.GetComponent<Animator> (); //tomatochick
		this.maxspeed = 10.0f;
		this.jumpinterval = 0f;

		this.GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();//Scene01から実行するとエラー
		if(GameDirectorScript.StageNumber == 1){ //ふえたらスイッチにしような
			this.InitPos = new Vector3(0f,30f,0f); //初期位置設定
		} //当たり前だが、startはシーンロード時に一度通るので、GameDirectorScript内の値を一定にしておけばなんでもできる。
		transform.position = this.InitPos;
	}
	
	// Update is called once per frame
	void Update () {
		jumpinterval += Time.deltaTime; //s ???

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
		}// else

		//アニメーション処理
		if(Mathf.Abs(this.RB.velocity.y) > 0.5f){
			this.animator.SetInteger("Fly", 1); //Animationのほう
			this.animator.speed = 3.0f; //飛んでるモーションは速い方が可愛い。
		}else{
			this.animator.SetInteger("Fly", 0);
			this.animator.speed = 1.0f;
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Finish") {
			Debug.Log ("Clear");
		}
	}
}
