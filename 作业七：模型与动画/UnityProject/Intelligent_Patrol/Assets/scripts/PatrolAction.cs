using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : SSAction {
	Vector3 aim; //目标位置
	float speed = 5f; //速度
	PatrolInfo chaserInfo = null;

	// Use this for initialization
	public override void Start () { //初始目标位置设置
		aim = this.transform.localPosition;
	}

	public static PatrolAction getAction(){
		return new PatrolAction ();
	}
	
	public override void Update () { //目标位置的更新
		if (chaserInfo != null) {
			if (chaserInfo.runner != null) { //当邻域存在runner时，目标设置为runner
				aim = chaserInfo.runner.transform.position - chaserInfo.getCheckerWorldLoc ();
			}

			gameobject.transform.localPosition = Vector3.MoveTowards (gameobject.transform.localPosition 
				, aim, speed * Time.deltaTime);
			gameobject.transform.LookAt (chaserInfo.getCheckerWorldLoc() + aim);
			if (aim == gameobject.transform.localPosition) {
				chaserInfo.setNewAim ();
			} 
		}

	}
		
	public void setAim(Vector3 newAim){
		aim = newAim;
	}

	public void setPatrolInfo(PatrolInfo info){
		chaserInfo = info;
	}
}
