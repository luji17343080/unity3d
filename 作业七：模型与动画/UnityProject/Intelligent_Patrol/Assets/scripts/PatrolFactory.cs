using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFactory: MonoBehaviour{

	public PatrolInfo getPatrol(){
		return new PatrolInfo ();
	}
}
