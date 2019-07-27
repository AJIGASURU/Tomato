using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour {
	public int StageNumber;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject); //これで破壊されない。
		StageNumber = 0; //意味のない初期化？？
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
