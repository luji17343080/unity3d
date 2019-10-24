using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	private float mosveSpeed = 10f; //移动速度
	private int nowDirection = 0; //方向
	private bool ifRun = false; //判断是否移动
	private bool ifAlreadyTurn = false; //判断是否已经改变方向
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { //根据游戏的状态更新player
		if (Director.getInstance ().CurrentSceneController.getGameStatus () == "running") {
			MoveControl ();
		}
	}

	void MoveControl(){ //玩家移动的控制函数 
		nowDirection = getDirection ();
		this.transform.eulerAngles = new Vector3 (0, nowDirection, 0); //设置当前玩家的方向
		if (ifRun) { //移动中的位置改变
			nowDirection = getDirection ();
			this.transform.Translate (0, 0, mosveSpeed * Time.deltaTime);
		}
	}

	int getDirection(){ //设置每种操作后的相对方向的改变
		int direction = 0;
		if (Input.GetKey(KeyCode.W)) { //当前为前进
			if (Input.GetKey (KeyCode.A)) { //左上移动
				direction = -45;
			}
			else if (Input.GetKey (KeyCode.D)) { //右上移动
				direction = 45;
			}
			else {
				direction = 360;
			}
		}  
		else if (Input.GetKey(KeyCode.S)) { //当前为后退  
			if (Input.GetKey (KeyCode.A)) {  //左下移动
				direction = -135;
			}
			else if (Input.GetKey (KeyCode.D)) { //右下移动
				direction = 135;
			}
			else {
				direction = 180;
			}
		}  
		else if (Input.GetKey(KeyCode.D)) { //当前为右移 
			direction = 90;
		}  
		else if (Input.GetKey(KeyCode.A)) { //当前为左移  
			direction = -90;
		}  

		if (direction != 0) {
			ifRun = true;
			return direction;
		}
		else {
			ifRun = false;
			return nowDirection;
		}
	}
	//碰撞事件设置：碰到patrol，游戏结束，发生刚体碰撞事件；碰到score，得分加1，score消失
	void OnCollisionEnter(Collision collision){ 
		string name = collision.gameObject.name;
		if (name == "patrol") { //碰撞物体为patrol，调用setGameOver函数结束游戏
			Singleton<EventManager>.Instance.setGameOver ();
			gameObject.GetComponent<Animator> ().SetBool ("ifStop", true);
		}
		else if (name.Length > 5 && name.Substring(0 , 5) == "score") { //碰到score，调用addScore函数得分加1
			Singleton<EventManager>.Instance.addScore (collision.gameObject.name);
			collision.gameObject.SetActive (false);
		}
	}
}
