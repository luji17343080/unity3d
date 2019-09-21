using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;
public class firstScenceSolveClick : MonoBehaviour {
	firstScenceUserAction action ;
	string characterName ;
	void Start () {	
		action = Director.getInstance().currentSceneController as firstScenceUserAction;
	}

	public void setName(string name){
		characterName = name;
	}

	void Update(){
	}

	void OnMouseDown(){
		if (action.getStatus() != "playing") {
			return;
		}
		else{
			if (characterName == "boat") {
				action.boatMove ();
			}
			else {
				action.getBoatOrGetShore (name);
			}
		}
	}
}