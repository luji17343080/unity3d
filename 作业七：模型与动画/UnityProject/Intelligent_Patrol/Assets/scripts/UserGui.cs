using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UserGui : MonoBehaviour {
	bool ifShowWin = false;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void OnGUI(){
		if (Director.getInstance ().CurrentSceneController.getGameStatus() == "gameover") {
			int score = Director.getInstance ().CurrentSceneController.getScore();
			string msg = "游戏结束！\n得分：" + score;
			GUI.Box (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 40, 100, 40), "");
			GUI.Label (new Rect (Screen.width / 2 - 20, Screen.height / 2 - 40, 100, 40), msg);
			string res = "重新开始";
			if (GUI.Button (new Rect (Screen.width / 2 - 40 , Screen.height / 2 + 10, 100, 40), res)){
				Director.getInstance().CurrentSceneController.reset();
			}
		}

	}
}