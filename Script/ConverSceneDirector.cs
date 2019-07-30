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
		this.DialogText = GameObject.Find ("CameraCanvas/DialogPanel/DialogText").GetComponent<Text> ();
		this.NameText = GameObject.Find ("CameraCanvas/DialogPanel/NameText").GetComponent<Text> ();
		this.Hitomi_image.SetActive (false);
		this.Tomato_image.SetActive (false);

		this.GameDirectorScript = GameObject.Find ("GameDirector").GetComponent<GameDirector> ();
		this.dialognum = 0;//会話番号の初期化
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) { 
			this.dialognum++;
		}
		switch (GameDirectorScript.StageNumber) {
		case 1:
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
			}
			break;
		case 2: //stagenumber
			switch (this.dialognum) {
			case 0:
				SetCharacter ("hitomi");
				this.DialogText.text = "ふふふ、面白い。\n転がって進むのね。";
				break;
			case 1:
				this.DialogText.text = "・・・";
				SetCharacter ("tomatochick");
				break;
			case 2:
				this.DialogText.text = "実はあなた、一瞬なら飛べるのよ。\n右下の羽、押してみてね。";
				SetCharacter ("hitomi");
				break;
			case 3:
				SetCharacter ("hitomi");
				this.DialogText.text = "羽が白い時にしか使えないから気をつけてね！";
				break;
			case 4:
				SetCharacter ("hitomi");
				this.DialogText.text = "それじゃ行ってらっしゃい。";
				break;
			case 5:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		case 3:
			switch (this.dialognum) {
			case 0:
				SetCharacter ("hitomi");
				this.DialogText.text = "どうもありがとう。\n2つめの花、げっとだね。";
				break;
			case 1:
				SetCharacter ("tomatochick");
				this.DialogText.text = "ところで君は誰？";
				break;
			case 2:
				SetCharacter ("hitomi");
				this.DialogText.text = "私の名前はヒトミ。\nわけあって花を集めてるの。";
				break;
			case 3:
				SetCharacter ("hitomi");
				this.DialogText.text = "君の名前は？";
				break;
			case 4:
				SetCharacter ("tomatochick");
				this.DialogText.text = "名前・・・僕の名前は・・・";
				break;
			case 5:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		case 4:
			switch (this.dialognum) {
			case 0:
				SetCharacter ("hitomi");
				this.DialogText.text = "あなたは道端に倒れていたの";
				break;
			case 1:
				SetCharacter ("tomatochick");
				this.DialogText.text = "どうもありがとう。\n助かったよ";
				break;
			case 2:
				SetCharacter ("hitomi");
				this.DialogText.text = "そのまえの記憶はないの？";
				break;
			case 3:
				SetCharacter ("tomatochick");
				this.DialogText.text = "断片的にしか覚えてない。";
				break;
			case 4:
				SetCharacter ("tomatochick");
				this.DialogText.text = "でもとにかくわかるのは\n今いる感じの場所とは、かけ離れた世界にいたこと。";
				break;
			case 5:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		case 5:
			switch (this.dialognum) {
			case 0:
				SetCharacter ("tomatochick");
				this.DialogText.text = "どうして花を集めているの？";
				break;
			case 1:
				SetCharacter ("hitomi");
				this.DialogText.text = "理由を聞くの？\n理由がなければダメ？";
				break;
			case 2:
				SetCharacter ("hitomi");
				this.DialogText.text = "ところでそれ、なんの花か知ってる？";
				break;
			case 3:
				SetCharacter ("tomatochick");
				this.DialogText.text = "いや、わからない。\nあまりみたことのない花だから。";
				break;
			case 4:
				SetCharacter ("hitomi");
				this.DialogText.text = "じゃあみたことのある花の名は知ってるの？";
				break;
			case 5:
				SetCharacter ("tomatochick");
				this.DialogText.text = "いや、わからない。";
				break;
			case 6:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		case 6:
			switch (this.dialognum) {
			case 0:
				SetCharacter ("hitomi");
				this.DialogText.text = "一つ教えてあげる";
				break;
			case 1:
				SetCharacter ("tomatochick");
				this.DialogText.text = "なんか偉そうだな・・・";
				break;
			case 2:
				SetCharacter ("hitomi");
				this.DialogText.text = "その花は「トマトの花」らしいわ。";
				break;
			case 3:
				SetCharacter ("tomatochick");
				this.DialogText.text = "トマト？なにそれ？";
				break;
			case 4:
				SetCharacter ("hitomi");
				this.DialogText.text = "聞いた話だと、ちゃんと育てれば実がなるらしいのだけど、\n私もそれはみたことはないの。";
				break;
			case 5:
				SetCharacter ("tomatochick");
				this.DialogText.text = "へ〜";
				break;
			case 6:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		case 7:
			switch (this.dialognum) {
			case 0:
				SetCharacter ("hitomi");
				this.DialogText.text = "あなたのことを教えて";
				break;
			case 1:
				SetCharacter ("tomatochick");
				this.DialogText.text = "僕は記憶があまりないんだ。でも日本語は覚えてる。";
				break;
			case 2:
				SetCharacter ("hitomi");
				this.DialogText.text = "会話ができているということね。";
				break;
			case 3:
				SetCharacter ("hitomi");
				this.DialogText.text = "果たして私たちは本当に会話してるのかしら。";
				break;
			case 4:
				SetCharacter ("hitomi");
				this.DialogText.text = "私たちは私たちしかいないのよ。";
				break;
			case 5:
				SetCharacter ("hitomi");
				this.DialogText.text = "第三者から見たら・・・";
				break;
			case 6:
				SceneManager.LoadScene ("Scene01");
				break;
			}
			break;
		default:
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