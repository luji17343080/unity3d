using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace baseCode{
	public class Director : System.Object {
		private static Director instance;
		public sceneController currentSceneController { get; set; }

		public sceneController CurrentSceneController{ get; set; }
		public static Director getInstance() {
			if (instance == null) {
				instance = new Director ();
			}
			return instance;
		}
	}

	public interface sceneController{
		void loadResources();
	}

	public interface UserAction{
		void reset();
	}
}

