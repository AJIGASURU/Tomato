﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : Button_Base {

	private bool ButtonOn;

	// Use this for initialization
	void Start () {
		this.ButtonOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (this.ButtonOn) {
			if (PlayerConScript.RB.velocity.x > -PlayerConScript.maxspeed) {
				PlayerConScript.RB.AddForce (Vector3.left * 100);
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