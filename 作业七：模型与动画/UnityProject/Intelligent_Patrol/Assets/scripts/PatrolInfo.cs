using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolInfo{
	public GameObject runner; //运动对象
	private GameObject patrol; //巡逻兵对象
	private PatrolAction patrolAc; //PatrolAction类的实例
	private int nowAim; //巡逻兵当前位置的目的地
	Vector3 checkerWorldLoc;//一个checker，用于跟踪player

	Vector3[] patrolLoc = { new Vector3 (4, 0, 0) , new Vector3 (0, 0, 4) 
								, new Vector3 (-4, 0, 0) , new Vector3 (0 , 0, -4) };


	public PatrolInfo(){ //预制的实例化
		patrol = Object.Instantiate (Resources.Load ("Prefabs/patrol") 
			, Vector3.zero , Quaternion.identity) as GameObject;
		runner = null;
		nowAim = 0;
		patrol.name = "patrol";
	}

	public void setParent(GameObject parent , Vector3 loc){ //每一个patrol的“父亲”的信息
		patrol.transform.parent = parent.transform;
		patrol.transform.localPosition = loc;
	}

	public void setNewAim(){ //设置新的目的地
		nowAim = (nowAim + 1) % patrolLoc.Length;
		patrolAc.setAim(patrolLoc[nowAim] );
	}

	public void setCheckerWorldLoc(Vector3 loc){
		checkerWorldLoc = loc;
		setAction ();
	}

	void setAction(){ //调用PatrolAction中的函数实现patrol的移动
		patrolAc = PatrolAction.getAction (); 
		patrolAc.setPatrolInfo (this);
		Singleton<CCActionManager>.Instance.RunAction(patrol, patrolAc , null );
	}

	public Vector3 getCheckerWorldLoc(){
		return checkerWorldLoc;
	}

	public void reset(){ //巡逻兵信息重置
		nowAim = 0;
		runner = null;
		setAction ();
		Singleton<CCActionManager>.Instance.RunAction(patrol, patrolAc , null );
	}
}
