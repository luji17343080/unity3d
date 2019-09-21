using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParabola3 : MonoBehaviour {
	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = this.gameObject.AddComponent<Rigidbody>();
		rigidbody.useGravity = false;
		// this.transform.position = new Vector3(0, 5, 0);
	}

	// Update is called once per frame
	void Update () {
		float x = this.transform.position.x;
		Vector3 speed = new Vector3(3, -x + 10, 0);
		rigidbody.MovePosition(transform.position + speed * Time.deltaTime);
	}
}
