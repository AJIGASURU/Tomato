using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageButton : MonoBehaviour { //メニューシーン用です。
	private GameDirector GameDirectorScript;
	private string ID;
	private int button_num;//ID_Textには数値が入っているがフォントが大きすぎるため表示されない（隠し要素）

	// Use this for initialization
	void Start () {
		this.GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
		this.ID = transform.GetChild (0).gameObject.GetComponent<Text>().text;
		this.button_num = int.Parse (ID);
	}
	
	// Update is called once per frame
	void Update () {
		if ((button_num - 1) > GameDirectorScript.ClearNumber) {
			gameObject.GetComponent<Button> ().interactable = false;
		} else {
			gameObject.GetComponent<Button> ().interactable = true;
		}
	}

	public void Onclick_1_1(){ //引数使えん？？？
		this.GameDirectorScript.StageNumber = 1;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_2(){
		this.GameDirectorScript.StageNumber = 2;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_3(){
		this.GameDirectorScript.StageNumber = 3;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_4(){
		this.GameDirectorScript.StageNumber = 4;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_5(){
		this.GameDirectorScript.StageNumber = 5;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_6(){
		this.GameDirectorScript.StageNumber = 6;
		SceneManager.LoadScene ("ConversationScene");
	}
	public void Onclick_1_7(){
		this.GameDirectorScript.StageNumber = 7;
		SceneManager.LoadScene ("ConversationScene");
	}
}
