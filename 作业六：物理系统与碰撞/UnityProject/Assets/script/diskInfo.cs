using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diskInfo{ //加载飞碟预制 
	public GameObject disk;	//disk的实例化对象 
	public int diskId; //用diskID标记飞碟 
	public int le;
	public diskInfo(int id , int le, bool ifPhysicManager){
		this.diskId = id;
		disk = GameObject.Instantiate(Resources.Load<GameObject>("prefabs/disk" ), Vector3.zero , Quaternion.identity);
		disk.name = "disk" + id.ToString ();
		if (ifPhysicManager && disk.GetComponents<Rigidbody>() != null ) {
			disk.AddComponent<Rigidbody> ();
		}
		reset (le);
	}

	public void reset(int lever){ //消失的飞碟位置重置 
		disk.transform.position = new Vector3 (Random.Range (-10f, 10f), Random.Range (-10f, 10f), Random.Range (0f, 2f));
		switch (lever) {
		case 1:
			disk.GetComponent<Renderer> ().material.color = Color.red;
			disk.transform.localScale = new Vector3 (3f, 0.3f, 3f);
			break;
		case 2:
			disk.GetComponent<Renderer> ().material.color = Color.yellow;
			disk.transform.localScale = new Vector3 (2f, 0.2f, 2f);
			break;
		default:
			disk.GetComponent<Renderer> ().material.color = Color.grey;
			disk.transform.localScale = new Vector3 (1f, 0.1f, 1f);
			break;
		}
		this.le = lever;
		disk.SetActive(true);
	}
}
