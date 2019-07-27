using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : Button_Base {

	private bool ButtonOn; //EventTrigger関係

	// Use this for initialization
	void Start () {
		this.ButtonOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (this.ButtonOn) {
			if (PlayerConScript.RB.velocity.z > -PlayerConScript.maxspeed) {
				PlayerConScript.RB.AddForce (Vector3.back * 100);
			}
		}
	}
	public void RightDown(){
		this.ButtonOn = true;
	}
	public void RightUp(){
		this.ButtonOn = false;
	}
}
