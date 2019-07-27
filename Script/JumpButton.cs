using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI用

public class JumpButton : Button_Base { //ジャンプボタン<ボタンベース

	private Vector2 Size; //ジャンプボタンのサイズ
	private Vector3 Rot;

	// Use this for initialization
	void Start () {
		this.Size = new Vector2 (300f, 300f);//だいぶ適当な初期化
		this.Rot = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		if (PlayerConScript.jumpinterval < 2f) { //jumpintervalは常に増加
			this.gameObject.GetComponent<Button> ().interactable = false; //disable化
			this.Size = new Vector2 (PlayerConScript.jumpinterval * 150f, PlayerConScript.jumpinterval * 150f); //だんだん大きくなる処理
			this.Rot = new Vector3((2f-PlayerConScript.jumpinterval)*100f,(2f-PlayerConScript.jumpinterval)*100f,0f);
			this.gameObject.GetComponent<RectTransform> ().sizeDelta = this.Size; //回転
			transform.rotation = Quaternion.Euler (this.Rot);

		} else {
			this.gameObject.GetComponent<Button> ().interactable = true; //able化
			this.Size = new Vector2 (300f, 300f);//一応初期k
			this.Rot = Vector3.zero;
		}
	}
	public void OnClick(){
		if (PlayerConScript.jumpinterval > 2f) { 
			PlayerConScript.RB.AddForce (Vector3.up * 500);
			PlayerConScript.jumpinterval = 0f;
		} 
	}
}
