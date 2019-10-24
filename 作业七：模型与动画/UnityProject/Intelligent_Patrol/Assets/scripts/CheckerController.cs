using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerController: MonoBehaviour{
	PatrolInfo patrol; //patrol实例
	GameObject score; //score实例
	Vector3 IniPos = Vector3.zero; //初始位置
	void Awake(){
		PatrolFactory patrolFactory = Singleton<PatrolFactory>.Instance; //patrol工厂单例
		patrol = patrolFactory.getPatrol(); //生产patrol
		patrol.setParent (this.gameObject, IniPos); 
		patrol.setCheckerWorldLoc (this.transform.position);
		//score预制的实例化，位置的初始化
		score = Object.Instantiate (Resources.Load ("Prefabs/score"), Vector3.zero, Quaternion.identity) as GameObject;
		score.transform.parent = this.gameObject.transform;
		score.transform.localPosition = Vector3.zero;
		score.name = "score" + this.gameObject.name.Substring (7);
	}

	public void reset(){//重置
		patrol.reset ();
		score.SetActive (true);
		patrol.setParent (this.gameObject, IniPos);
	}

	// 入口设置
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "player")
			patrol.runner = collider.gameObject;
	}

	//出口设置
	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "player")
			patrol.runner = null;
	}
}
