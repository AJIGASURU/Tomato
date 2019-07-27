using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour { //メニューシーン用です。
	private GameDirector GameDirectorScript;

	// Use this for initialization
	void Start () {
		this.GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Onclick_1_1(){
		this.GameDirectorScript.StageNumber = 1;
		SceneManager.LoadScene ("ConversationScene");
	}
}
