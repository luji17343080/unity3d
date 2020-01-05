using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Track : MonoBehaviour
{
	public GameObject targetTank; // 设置目标坦克
	NavMeshAgent nma;  // 添加NavMeshAgent组件
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		// 调用SetDestination设置智能组件的目标位置
		GetComponent<NavMeshAgent>().destination= targetTank.transform.position;
	}
}
