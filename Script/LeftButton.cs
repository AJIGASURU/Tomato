using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : Button_Base { //継承

	private bool ButtonOn; //EventTrigger

	// Use this for initialization
	void Start () {
		this.ButtonOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (this.ButtonOn) {
			if (PlayerConScript.RB.velocity.z < PlayerConScript.maxspeed) { //thisって基底クラスの参照できんの？
				PlayerConScript.RB.AddForce (Vector3.forward * 100);
			}
		}
	}
	public void LeftDown(){
		this.ButtonOn = true;
	}
	public void LeftUp(){
		this.ButtonOn = false;
	}
}
