using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour { //兼音楽家
	public int StageNumber; //今のステージ
	public int ClearNumber; //どのステージまでクリア済みか
	public AudioSource[] sources;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject); //これで破壊されない。
		StageNumber = -1; //0->メニューシーン、-1->タイトル
		ClearNumber = PlayerPrefs.GetInt("ClearNumber",0); //ロード

		sources = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//データ自動保存はプレイヤスクリプトで行なっている。デバッグ時の初期化
        // PlayerPrefs.SetInt("ClearNumber" , 0);  


		if (StageNumber == -1) { //タイトル
			if (Input.GetMouseButtonDown (0)) {
				StageNumber++;
				SceneManager.LoadScene ("MenuScene");
			}
		}

		//おーでお
		if(StageNumber<=0){
			if (sources [0].isPlaying == false) {
				sources [0].Play ();
			}
		}else{
			if (sources [0].isPlaying == true) {
				sources [0].Stop ();
			}
		}
		if(StageNumber>0){
			if (sources [1].isPlaying == false) {
				sources [1].Play ();
			}
		}else{
			if (sources [1].isPlaying == true) {
				sources [1].Stop ();
			}
		}
	}
}
