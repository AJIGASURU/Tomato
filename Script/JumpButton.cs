using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour {
	public GameObject Player; //Armature これいちいちめんどいからさっさと基底クラス作れ！
	private PlayerCon PlayerConScript; //プレイやオブジェクトからスクリプトもらいましょう！
	// Use this for initialization
	void Start () {
		this.PlayerConScript = Player.GetComponent<PlayerCon> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick(){
		if (Mathf.Abs (this.PlayerConScript.RB.velocity.y) < 0.01f) { //この条件だと斜めな場所でジャンプできないんじゃ！
			this.PlayerConScript.RB.AddForce (Vector3.up * 500);
		}
	}
}
