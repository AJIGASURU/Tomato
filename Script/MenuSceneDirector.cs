using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneDirector : MonoBehaviour {
	/*
ボタン群の位置制御
	*/
	private GameObject Panel;
	private Vector3 DownPos;
	private Vector3 NowPos;
	private Vector3 ScrollPos;

	// Use this for initialization
	void Start () {
		this.Panel = GameObject.Find ("Canvas/Panel");
		this.ScrollPos = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		this.NowPos = Input.mousePosition;
		if (Input.GetMouseButtonDown (0)) {
			this.DownPos = Input.mousePosition;
		}
		if (Input.GetMouseButton(0)) {
			if (ScrollPos.y >= 0) {
				ScrollPos.y += DownPos.y - NowPos.y;//できねえからこれでいいやろ！！（適当）
			}
		}
		if (ScrollPos.y < 0) {
			ScrollPos.y = 0; //変なところ行くと動かないので。
		}
		if (ScrollPos.y > 100f) { //スクロール限界値
			ScrollPos.y = 100f; 
		}
		Panel.GetComponent<RectTransform> ().localPosition = ScrollPos;
	}
}
