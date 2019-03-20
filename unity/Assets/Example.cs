using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        HiLog.SetOn(true);

        Debug.Log("this is from start");

        Debug.LogWarning(456);
        Debug.LogError(789);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(566544161);
    }
}
