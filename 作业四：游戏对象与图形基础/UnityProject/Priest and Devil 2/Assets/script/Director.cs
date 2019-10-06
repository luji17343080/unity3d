using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baseCode{
	public class Director : System.Object {
		private static Director _instance;
		public sceneController currentSceneController { get; set; } // 场景控制 

		public sceneController CurrentScenceController{ get; set; }
		public static Director getInstance() {
			if (_instance == null) {

				_instance = new Director ();
			}
			return _instance;
		}
	}

	public interface sceneController{ //场景控制接口 
		void loadResources(); //加载Resources中的预制 

	}
}

public interface UserAction{ //角色Action接口 

}

public interface firstScenceUserAction: UserAction{ //初始场景控制接口 
	void boatMove (); //船移动函数 
	void getBoatOrGetShore (string name); //将预制实例化 
	void reset(); //游戏重置 
    string getStatus(); //得到此时游戏的状态 
}