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
        Debuger_Hi.EnableOnConsole(true);
        Debuger_Hi.Log("hello");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
