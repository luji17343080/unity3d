using UnityEngine;

public class IMGUI_HealthBar : MonoBehaviour {
	public float initHealth = 50; //初始血量
	public float resultHealth = 50; //增减后血量

	private Rect HealthBar; //血条
	private Rect AddBlood; //加血
	private Rect SubBlood; //减血

	void Start () {

	}

	void OnGUI () {
		HealthBar = new Rect((Screen.width - 200) / 2, (Screen.height - 60) / 2, 200, 40); //血条框
		AddBlood = new Rect((Screen.width + 220)/ 2, (Screen.height - 60) / 2, 20, 20); //加血按钮
		SubBlood = new Rect((Screen.width - 260)/ 2, (Screen.height - 60) / 2, 20, 20); //减血按钮

		if (GUI.Button(AddBlood, "+"))
			resultHealth = initHealth + 10 > 100 ? 100 : initHealth + 10;
		if (GUI.Button(SubBlood, "-"))
			resultHealth = initHealth - 10 < 0 ? 0 : initHealth - 10;
		GUI.color = Color.red;  //颜色设置
		initHealth = Mathf.Lerp(initHealth, resultHealth, 0.1f); //进度条显示
		GUI.HorizontalScrollbar(HealthBar, 0, initHealth, 0, 100);
	}
}
