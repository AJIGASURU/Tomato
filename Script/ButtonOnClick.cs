using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnClick : Button_Base {
	private GameObject ResumeButton;
	private GameObject PoseButton;
	private GameObject ReturnButton;

	// Use this for initialization
	void Start () {
		this.ResumeButton = GameObject.Find ("OverlayCanvas/ResumeButton");
		this.PoseButton = GameObject.Find ("OverlayCanvas/PoseButton");
		this.ReturnButton = GameObject.Find ("OverlayCanvas/ReturnButton");
		this.ResumeButton.SetActive (false);
		this.ReturnButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PoseOnClick(){
		Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
		PlayerConScript.OnPose = true; //junpinterval止めるため。
		this.ResumeButton.SetActive (true);
		this.ReturnButton.SetActive (true);
		this.PoseButton.SetActive (false);
	}
	public void ResumeOnClick(){
		Player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		PlayerConScript.OnPose = false;
		this.ResumeButton.SetActive (false);
		this.ReturnButton.SetActive (false);
		this.PoseButton.SetActive (true);
	}
	public void ReturnOnClick(){
		PlayerConScript.GameDirectorScript.StageNumber = 0;//一応の初期化。いらないかも。このオブジェクトはシーン遷移で破壊されないので初期化が厄介？
		SceneManager.LoadScene ("MenuScene"); //ここが最後
	}
}
