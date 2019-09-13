using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject a = GameObject.Find ("chair_");
		Debug.Log ("Find " + a + " with name!");
		GameObject b = GameObject.Find ("chair (1)");
		Debug.Log ("Find " + b + " with name!");
		GameObject c = GameObject.Find ("chair (2)");
		Debug.Log ("Find " + c + " with name!");
		GameObject d = GameObject.FindWithTag ("Finish");
		Debug.Log ("Find " + d + " with Tag!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
