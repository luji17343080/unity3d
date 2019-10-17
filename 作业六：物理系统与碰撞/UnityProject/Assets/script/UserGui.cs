using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class UserGui : MonoBehaviour {
	roundController roundCtrl;
	bool ifShowWin = false;
	void Start () {
		roundCtrl = (roundController)Director.getInstance ().currentSceneController;
	}
	
	// Update is called once per frame
	void Update () {
		if (roundCtrl.status == "游戏结束" || roundCtrl.status == "暂停") {
			return;
		}
		checkClick ();
	}

	void OnGUI(){
		string showButtonText;
		GUI.Box (new Rect (15, 15, 120, 50) ,"");
		GUI.Label (new Rect (15, 15, 120, 25), "游戏状态: " + roundCtrl.status);
		GUI.Label (new Rect (15, 40, 120, 25), "得分情况: " + roundCtrl.scoreCtrl.getScore() );
		if (roundCtrl.status == "进行中") {
			showButtonText = "暂停";
		} 
		else if(roundCtrl.status == "游戏结束" ) {
			showButtonText = "开始";
		}
		else  { //status = pause
			showButtonText = "继续";
		}

		if (GUI.Button (new Rect (15, 70, 120, 30), showButtonText)) {
			if (showButtonText == "继续") {
				roundCtrl.status = "进行中";
			} else if (showButtonText == "开始") {
				roundCtrl.status = "进行中";
				roundCtrl.reset ();
			} else {
				roundCtrl.status = "暂停";
			}
		}

		if (GUI.Button (new Rect (15, 110, 120, 30), "重新开始")) {
			
			roundCtrl.status = "进行中";
			roundCtrl.reset ();
		}
			
	}

	void checkClick(){
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mp = Input.mousePosition;
			Camera ca = Camera.main;
			Ray ray = ca.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				((roundController)Director.getInstance ().currentSceneController).hitDisk (hit.transform.gameObject);
			}
		}
	}
}
