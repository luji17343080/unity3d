﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class roundController : MonoBehaviour ,sceneController , UserAction {
	public string status = "进行中";
	DiskFactory diskFac ;
	public bool ifPhysicManager = false;
	int roundLevel = 1;
	int numOfDiskAlredySend = 0;
	float time = 0;
	float sendDiskTime = 1;

	SSActionManager actionManager;
	public ScoreController scoreCtrl = new ScoreController();

	void Awake(){
		Director director = Director.getInstance ();
		director.currentSceneController = this;
		this.gameObject.AddComponent<DiskFactory>();
		//this.gameObject.AddComponent<CCActionManager> ();
		this.gameObject.AddComponent<UserGui> ();

	}
	// Use this for initialization
	void Start () {
	    diskFac = Singleton<DiskFactory>.Instance;
		if (ifPhysicManager) {
			actionManager = gameObject.AddComponent<physicActionManager>();
		} else {
			actionManager = gameObject.AddComponent<CCActionManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (status == "暂停" || status == "游戏结束") {
			return;
		} 
		else if (roundLevel > 3) {
			if(diskFac.getUsedDisk() == 0)
				status = "游戏结束";
			return;
		}
		else if (numOfDiskAlredySend >= 10) {
			numOfDiskAlredySend = 0;
			roundLevel++;
		}
		time += Time.deltaTime ;
		checkIfSendDisk ();

	}


	public void hitDisk(GameObject disk){
		diskInfo temp = diskFac.getHitDisk (disk);
		if (temp == null) {
			Debug.Log ("the disk of clicked is null? ");
		} else {
			scoreCtrl.addScore (temp.le);
			diskFac.freeDisk (temp);
		}

	
	}

	private void checkIfSendDisk(){
		if(time > sendDiskTime){
			float randomNumOfSend = Random.Range (0f, roundLevel);
			int numOfSendDisk;
			if (randomNumOfSend <= 1) {
				numOfSendDisk = 1;
			} else if (randomNumOfSend <= 2) {
				numOfSendDisk = 2;
			} else {
				numOfSendDisk = 3;
			}
			sendSomeDisks (numOfSendDisk);
			time = 0;
		}
	}

	private void sendSomeDisks(int num){
		for (int loop = 0; loop < num; loop++) {
			float randomNumOfLever = Random.Range (0f, roundLevel);
			int thisDiskLever;
			if (randomNumOfLever <= 1) {
				thisDiskLever = 1;
			} else if (randomNumOfLever <= 2) {
				thisDiskLever = 2;
			} else {
				thisDiskLever = 3;
			}
			sendOneDisk (thisDiskLever);
		}
	}

	private void sendOneDisk(int sendLever){
		numOfDiskAlredySend++;
		diskInfo oneDisk = diskFac.getDisk ( sendLever, ifPhysicManager);
		diskMove moveAction = diskMove.getDiskMove(oneDisk , sendLever, ifPhysicManager);
		actionManager.RunAction (oneDisk.disk , moveAction , null);
	}

	public void loadResources(){
		
	}

	public void reset(){
		actionManager.reset ();
		diskFac.reset ();
		scoreCtrl.reset ();
		roundLevel = 1;
		numOfDiskAlredySend = 0;
		status = "进行中";
	}

}
