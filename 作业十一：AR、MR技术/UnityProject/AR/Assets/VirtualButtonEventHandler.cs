﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    // 创建虚拟按钮
    public GameObject vb;
    public Animator an;
    // 按键事件
    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonBehaviour vb)
    {
        an.SetBool("Swing", true);
        Debug.Log("swing!");
    }
    
    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonBehaviour vb)
    {
        an.SetBool("Swing", false);
        Debug.Log("static!");
    }
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour flag = vb.GetComponent<VirtualButtonBehaviour>();
        if(flag)
        {
            flag.RegisterEventHandler(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}