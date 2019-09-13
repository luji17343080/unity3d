using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject table_ = GameObject.CreatePrimitive (PrimitiveType.Cube);
		table_.name = "newTable";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
