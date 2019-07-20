using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {
	public GameObject Player; //Armature これいちいちめんどいからさっさと基底クラス作れ！
	private PlayerCon PlayerConScript; //プレイやオブジェクトからスクリプトもらいましょう！

	private bool ButtonOn;

	// Use this for initialization
	void Start () {
		this.ButtonOn = false;
		this.PlayerConScript = Player.GetComponent<PlayerCon> ();
	}

	// Update is called once per frame
	void Update () {
		if (this.ButtonOn) {
			if (this.PlayerConScript.RB.velocity.x > -this.PlayerConScript.maxspeed) {
				this.PlayerConScript.RB.AddForce (Vector3.left * 100);
			}
		}
	}
	public void BackDown(){
		this.ButtonOn = true;
	}
	public void BackUp(){
		this.ButtonOn = false;
	}
}