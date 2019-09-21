using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParabola : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float x = this.transform.position.x;
		this.transform.position = new Vector3(x + 1.0f * Time.deltaTime,-0.2f * x * (x - 20), 0);

	}

}
