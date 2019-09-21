using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParabola2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float x = this.transform.position.x;
		//x方向
		this.transform.Translate(Vector3.right * Time.deltaTime * 5);
		//y方向
		this.transform.Translate(Vector3.up * Time.deltaTime * (-0.5f * x + 10));
	}
}
