using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConverSceneDirector : MonoBehaviour { //ダイアログシーン
	private GameObject Hitomi_image;
	private GameObject Tomato_image;
	private Text DialogText;
	private Text NameText;
	private int dialognum;

	private GameDirector GameDirectorScript; //草、これまとめたいな。
	// Use this for initialization
	void Start () {
		this.Hitomi_image = GameObject.Find ("CameraCanvas/hitomi_Image");
		this.Tomato_image = GameObject.Find ("CameraCanvas/tomato_Image");
		this.DialogText = GameObject.Find ("CameraCanvas/DialogPanel/DialogText").GetComponent<Text>();
		this.NameText = GameObject.Find ("CameraCanvas/DialogPanel/NameText").GetComponent<Text>();
		this.Hitomi_image.SetActive (false);
		this.Tomato_image.SetActive (false);

		this.GameDirectorScript = GameObject.Find("GameDirector").GetComponent<GameDirector>();
		if(GameDirectorScript.StageNumber == 1){ //ふえたらスイッチにしような
			this.dialognum = 0;
			}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			this.dialognum++;
		}
		switch (this.dialognum) {
		case 0:
			SetCharacter ("tomatochick");
			this.DialogText.text = "ん...ここは？";
			break;
		case 1:
			SetCharacter ("hitomi");
			this.DialogText.text = "気が付いた？\nあなた、随分可愛い姿をしているようだけど。";
			break;
		case 2:
			SetCharacter ("tomatochick");
			this.DialogText.text = "か...かわいい！？";
			break;
		case 3:
			SetCharacter ("hitomi");
			this.DialogText.text = "あのね、お願いがあるんだけど、\n花を、集めて欲しいの。";
			break;
		case 4:
			SetCharacter ("tomatochick");
			this.DialogText.text = "花？";
			break;
		case 5:
			SceneManager.LoadScene ("Scene01");
			break;
		default:
			this.DialogText.text = "会話入力がありません";
			break;
		}
	}

	private void SetCharacter(string charaname){
		switch (charaname) {
		case "tomatochick":
			this.Hitomi_image.SetActive (false);
			this.Tomato_image.SetActive (true);
			this.NameText.text = "トマトチック:";
			break;
		case "hitomi":
			this.Hitomi_image.SetActive (true);
			this.Tomato_image.SetActive (false);
			this.NameText.text = "ヒトミ:";
			break;
		default:
			this.DialogText.text = "名前の入力がありません";
			break;
		}
	}
}