using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour {
	void Awake() {
		Debug.Log ("Awake!");	
	}

	void Start() {
		Debug.Log ("Start!");
	}

	void Update() {
		Debug.Log ("Update!");
	}

	void FixeUpdate() {
		Debug.Log ("FixeUpdate!");
	}

	void LateUpdate() {
		Debug.Log ("LateUpdate!");
	}

	void OnGUI() {
		Debug.Log ("OnGUI!");	
	}

	void OnDisable() {
		Debug.Log ("OnDisable");
	}

	void OnEnable() {
		Debug.Log ("OnEnable");
	}

}