using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController{
	GameObject player;
	Vector3 IniPos = Vector3.zero; //初始位置
	public PlayerController(){ //预制的实例化
		player = Object.Instantiate (Resources.Load ("Prefabs/player"), IniPos , Quaternion.identity) as GameObject;
		player.AddComponent<PlayerMove> ();
		player.GetComponent<Animator>().SetBool ("ifStop", false);
		player.name = "player";
	}

	public GameObject getPlayer(){
		return player;
	}

	public void reset(){ //玩家信息重置
		player.transform.position = IniPos;
		player.GetComponent<Animator>().SetBool ("ifStop", false);

	}
}
