using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour { //アタッチはMainCamera、カメラ制御
	public GameObject Player; //Armature
	private Vector3 CameraPos;

	// Use this for initialization
	void Start () {
		CameraPos.x = Player.transform.position.x - 20;
		CameraPos.y = Player.transform.position.y + 10;
		CameraPos.z = Player.transform.position.z;

		transform.position = CameraPos;
	}
	
	// Update is called once per frame
	void Update () {
		CameraPos.x = Player.transform.position.x - 20;
		CameraPos.y = Player.transform.position.y + 10;
		CameraPos.z = Player.transform.position.z;

		if (Player.transform.position.y > -20.0f) { //死んだ処理、カメラバージョン
			transform.position = CameraPos; //落ちてない場合にのみポジションの変更をし続ける。
		}
	}
}
