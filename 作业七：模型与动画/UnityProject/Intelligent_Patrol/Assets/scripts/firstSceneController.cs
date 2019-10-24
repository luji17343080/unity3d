using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstSceneController : MonoBehaviour ,  sceneController {
	//patrol所在的8个块对应8个checker
	Vector3[] checkerLoc = 
					{new Vector3(10 , 0 , -10 ) ,new Vector3(10 , 0 , 0 ) , new Vector3(10 , 0 , 10) ,
					new Vector3(0 , 0 , -10 )  ,new Vector3(0 , 0 , 10 ) ,
					new Vector3(-10 , 0 , -10 ) ,new Vector3(-10 , 0 , 0 ) ,new Vector3(-10 , 0 , 10 ) ,};
	CheckerController[] checkerCtrl;
	PlayerController playerCtrl;
	string gameStatus = "running"; //初始状态为running
	ScoreController scoreCtrl;
	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreCtrl.getScore () == checkerLoc.Length) {
			gameStatus = "gameover";
		}
	}

	void OnEnable(){
		EventManager.gameover += setGameOver;
	}

	void OnDisable(){
		EventManager.gameover -= setGameOver;
	}

	void setGameOver(){
		gameStatus = "gameover";
	}

	void init(){ //场景的初始化，包括UI、场景中的对象添加、计分器的设置等
		this.gameObject.AddComponent<PatrolFactory>();
		this.gameObject.AddComponent<CCActionManager>();
		this.gameObject.AddComponent<EventManager>();
		this.gameObject.AddComponent<UserGui>();
		scoreCtrl = this.gameObject.AddComponent<ScoreController>();
		Director director = Director.getInstance ();
		director.CurrentSceneController = this;
		loadResources ();
	}

	public void loadResources(){ //地图和checker预制的实例化
		Object.Instantiate (Resources.Load ("Prefabs/map"), Vector3.zero, Quaternion.identity);
		checkerCtrl = new CheckerController[checkerLoc.Length];
		playerCtrl = new PlayerController ();
		for (int loop = 0 ; loop < checkerLoc.Length ; loop++) {
			GameObject checker = Object.Instantiate (Resources.Load ("Prefabs/checker")
				, checkerLoc[loop] , Quaternion.identity) as GameObject;
			checker.name = "checker" + loop.ToString ();
			checkerCtrl[loop] = checker.AddComponent(typeof (CheckerController)) as CheckerController;
		
		}
	}

	public void reset(){ //游戏重置
		gameStatus = "running";
		for (int loop = 0 ; loop < checkerLoc.Length ; loop++) {
			checkerCtrl [loop].reset ();
		}
		playerCtrl.reset ();
		scoreCtrl.reset ();
	}

	public string getGameStatus(){ //获得游戏状态
		return gameStatus;
	}

	public int getScore(){ //获得计分器分数
		return scoreCtrl.getScore ();
	}
}
