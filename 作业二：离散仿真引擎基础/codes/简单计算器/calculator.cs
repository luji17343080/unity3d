using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculator : MonoBehaviour{
	private List<float>num = new List<float>(); //存所有数字
	private List<float>op = new List<float>(); //存所有操作符
	private string result = "";
	private bool isCE = false; //判断前一步操作是否是“CE”
	private bool isEq = false; //判断前一步操作是否是“=”

	bool isNum(char c) { //判断字符是否数字
		return (c == '0' || c == '1' || c == '2' || c == '3' ||
			c == '4' || c == '5' || c == '6' || c == '7' ||
			c == '8' || c == '9' || c == '.');
	}

	bool isOp(char c) { //判断字符是否操作符
		return (c == '+' || c == '-' || c == 'x' || c == '/');
	}

	// UI
	void OnGUI() {
		//数字Button，若前一步操作是CE或=或者result是0，数字重置，
		if (GUI.Button(new Rect(100, 380, 210, 60), "0")) {
			if (isCE || isEq || result == "0") {
				result = "0";
				isCE = false;
				isEq = false;
			}
			else result += "0";
		}
		if (GUI.Button(new Rect(100, 170, 100, 60), "1")) {
			if (isCE || isEq || result == "0") {
				result = "1";
				isCE = false;
				isEq = false;
			}
			else result += "1";
		}
		if (GUI.Button(new Rect(210, 170, 100, 60), "2")) {
			if (isCE || isEq || result == "0") {
				result = "2";
				isCE = false;
				isEq = false;
			}
			else result += "2";
		}
		if (GUI.Button(new Rect(320, 170, 100, 60), "3")) {
			if (isCE || isEq || result == "0") {
				result = "3";
				isCE = false;
				isEq = false;
			}
			else result += "3";
		}
		if (GUI.Button(new Rect(100, 240, 100, 60), "4")) {
			if (isCE || isEq || result == "0") {
				result = "4";
				isCE = false;
				isEq = false;
			}
			else result += "4";
		}
		if (GUI.Button(new Rect(210, 240, 100, 60), "5")) {
			if (isCE || isEq || result == "0") {
				result = "5";
				isCE = false;
				isEq = false;
			}
			else result += "5";
		}
		if (GUI.Button(new Rect(320, 240, 100, 60), "6")) {
			if (isCE || isEq || result == "0") {
				result = "6";
				isCE = false;
				isEq = false;
			}
			else result += "6";
		}
		if (GUI.Button(new Rect(100, 310, 100, 60), "7")) {
			if (isCE || isEq || result == "0") {
				result = "7";
				isCE = false;
				isEq = false;
			}
			else result += "7";
		}
		if (GUI.Button(new Rect(210, 310, 100, 60), "8")) {
			if (isCE || isEq || result == "0") {
				result = "8";
				isCE = false;
				isEq = false;
			}
			else result += "8";
		}
		if (GUI.Button (new Rect (320, 310, 100, 60), "9")) {
			if (isCE || isEq || result == "0") {
				result = "9";
				isCE = false;
				isEq = false;
			}
			else result += "9";
		}

		//运算符Button
		if (GUI.Button(new Rect(430, 240, 100, 60), "+")) {
			isCE = false;
			isEq = false;
			result += "+";
		}
		if (GUI.Button (new Rect (430, 170, 100, 60), "-")) {
			isCE = false;
			isEq = false;
			result += "-";
		}
		if (GUI.Button (new Rect (320, 100, 100, 60), "x")) {
			isCE = false;
			isEq = false;
			result += "x";
		}
		if (GUI.Button (new Rect (210, 100, 100, 60), "/")) {
			isCE = false;
			isEq = false;
			result += "/";
		}

		//功能Button
		if (GUI.Button(new Rect(320, 380, 100, 60), ".")) {
			isCE = false;
			isEq = false;
			result += ".";

		}
		if (GUI.Button (new Rect (100, 100, 100, 60), "CE")) { // 清零
			result = "0";
			isCE = true;
		}
		if (GUI.Button(new Rect(430, 100, 100, 60), "←")) result = result.Substring(0, result.Length - 1); //回退，注意只能在result不是空的情况下操作
		if (GUI.Button(new Rect(430, 310, 100, 130), "=")) {
			isEq = true;

			string num_ = "";
			for (int i = 0; i < result.Length; i++) {
				if (result[0] == '-'){ //若第一个字符是“-”，在result前面加“0”
					result = "0" + result;
				}
				if (i == result.Length - 1) { //最后一个字符必是数字
					num_ += result[i];
					num.Add(float.Parse(num_));
				}

				else if (isNum(result[i])) {
					num_ += result[i];
				}

				else {
					num.Add(float.Parse(num_));
					num_ = "";
					if (isOp(result[i])) {
						op.Add(result[i]);
					}
				}
			}
			//先算“x” 和 “/”
			for (int i = 0; i < op.Count; i++) {
				if(op[i] == 'x' || op[i] == '/') {
					float tmp;
					if (op[i] == 'x') tmp = num[i] * num[i + 1];
					else tmp = num[i] / num[i + 1];
					num.RemoveAt(i);
					num[i] = tmp;
					op.RemoveAt(i);
					i--;
				}
			}
			// 再算“+” 和 “-” 
			for (int i = 0; i < op.Count; i++) {
				float tmp;
				if (op[i] == '+') tmp = num[i] + num[i + 1];
				else tmp = num[i] - num[i + 1];
				num.RemoveAt(i);
				num[i] = tmp;
				op.RemoveAt(i);
				i--;
			}
			result = num[0].ToString();
			num.Clear();
			op.Clear();
		}
		GUI.TextArea(new Rect(100, 20, 430, 60), result);
	}


	void Start() {

	}

	void Update() {

	}
}