using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButton : Button_Base {

	private bool ButtonOn;

	// Use this for initialization
	void Start () {
		this.ButtonOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (this.ButtonOn) {
			if (PlayerConScript.RB.velocity.x < PlayerConScript.maxspeed) {
				PlayerConScript.RB.AddForce (Vector3.right * 100);
			}
		}
	}
	public void GoDown(){
		this.ButtonOn = true;
	}
	public void GoUp(){
		this.ButtonOn = false;
	}
}