using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using baseCode ;

public class FirstSceneGuiCtrl : MonoBehaviour {
	firstScenceUserAction action ;
	bool show = true;	//判断是否出现游戏规则框
	string ruletext = "                游戏规则         点击岸上的方块（黑色代表恶魔，白色代表牧师）让其上船或上岸，点击船体让船过河，其中船上的人数为1-2。" +
		"游戏胜利的条件是让所有恶魔和牧师全部过河上岸，且在过程中保持任何一边的牧师数不少于恶魔数，当某一时刻不符合此条件时，游戏失败！";
	void Start () {
		action = Director.getInstance().currentSceneController as firstScenceUserAction;
	}

	void OnGUI () {
		firstScenceUserAction action = Director.getInstance().currentSceneController as firstScenceUserAction;
		string status = action.getStatus ();
		if (show == true) {
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 250, 200, 160), "");
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 250, 200, 180), ruletext);
			if(	GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 50), "开始游戏") ){
				show = false;
			} 

		}

		if (status == "playing") {
			if (GUI.Button (new Rect(Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 50), "重启游戏")) {
				action.reset ();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 160, 100, 50), "游戏规则")) {
				show = true;
			}
		}
		else { //游戏结果信息 
			string resultMsg;
			if (status == "lost") {
				resultMsg = "牧师被吃了！";
			} 
			else {
				resultMsg = "邪不胜正！！";
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), resultMsg)) {
				action.reset ();
				//show = true;
				//flag = false;
				//status = "playing";
			}
		}
	}
}
