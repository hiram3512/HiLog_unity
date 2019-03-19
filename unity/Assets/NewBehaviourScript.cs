using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        HiLog.SetOn(true);
        test();


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(566544161);
    }

    void test()
    {
        Debug.Log("hello");
        Debug.LogError("world");
        Debug.Log("123");
        Debug.LogWarning(456);
        Debug.LogError(789);
    }
}
