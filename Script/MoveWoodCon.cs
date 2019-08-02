using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWoodCon : MonoBehaviour { //削除するため

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -60.0f) { //y方向がたて次元
			Destroy(gameObject);
		}
	}
}
