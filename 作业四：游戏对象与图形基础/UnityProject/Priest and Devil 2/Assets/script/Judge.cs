using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour {
	public string gameStatus;
	void Start() {
		gameStatus = "playing";
	}
	// Update is called once per frame
	void Update() {

	}

	public string getStatus() {
		return gameStatus;
	}

	public void setStatus(string status) {
		gameStatus = status;
	}
}
