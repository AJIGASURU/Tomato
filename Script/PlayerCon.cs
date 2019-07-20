using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour { //アタッチはArmature、アニメーション時にArmatureが動くというバグがある。
	// publicの理由はGoButton.csでこのスクリプトが使われるから。
	public Rigidbody RB;
	public float maxspeed;

	private Animator animator;
	private float degreethreshold;

	// Use this for initialization
	void Start () {
		this.RB = GetComponent<Rigidbody> ();
		this.animator = transform.root.gameObject.GetComponent<Animator> (); //tomatochick
		this.maxspeed = 10.0f;
		this.degreethreshold = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.platform == RuntimePlatform.IPhonePlayer) { //あいぽん
			//左右のみ
			/*
			if (Input.acceleration.x > this.degreethreshold) { //右
				if (this.RB.velocity.z > -maxspeed) {
					this.RB.AddForce (Vector3.back * 100);
				}
			}
			if (Input.acceleration.x < -this.degreethreshold) { //左
				if (this.RB.velocity.z < maxspeed) {
					this.RB.AddForce (Vector3.forward * 100);
				}
			}
			*/

		} else { //パソコン
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
				if (Mathf.Abs (this.RB.velocity.y) < 0.01f) {
					this.RB.AddForce (Vector3.up * 500);
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
}
