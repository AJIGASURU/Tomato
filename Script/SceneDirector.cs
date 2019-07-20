using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour { //とりあえずのシーンディレクター
	public GameObject Player; //Armature

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.transform.position.y < -50.0f) { //y方向がたて次元
			SceneManager.LoadScene ("Scene01");
		}
	}
}
