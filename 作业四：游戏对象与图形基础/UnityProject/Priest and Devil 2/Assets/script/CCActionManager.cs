using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using baseCode;

public class CCActionManager : SSActionManager, ISSActionCallback {
	void Awake(){
		
	}

	void Start() {
		
	}
		
	public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,int intParam = 0, string strParam = null, Object objectParam = null) {

	}
}