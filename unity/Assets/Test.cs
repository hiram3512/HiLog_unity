//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debuger_Hi.EnableOnScreen(true);
        Debuger_Hi.Log("hello");

        Debuger_Hi.LogWarning(1 == 2);
        Do();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Do()
    {
        Debuger_Hi.LogError("from?");
    }
}
