using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class father : MonoBehaviour {
	string msg = "Hello, son!";
	// Use this for initialization
	void Start () {
		this.BroadcastMessage ("Child", msg);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
