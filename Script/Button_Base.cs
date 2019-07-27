using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Base : MonoBehaviour { //ボタン群の親クラス、どこにもアタッチされていない。
	//protectedは派生クラスのみ利用可能
	protected GameObject Player{ //プロパティ→結局変数のように使える。
		get{
			return GameObject.Find("tomatochick/Armature");
		}
		set{
			//これsetがどう動くのか不明すぎん？？
		}
	}
	protected PlayerCon PlayerConScript{
		get{
			return GameObject.Find("tomatochick/Armature").GetComponent<PlayerCon>();
		}
		set{
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
