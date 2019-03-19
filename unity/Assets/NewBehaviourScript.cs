using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var go = new GameObject("go");
	    go.AddComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void test()
    {
        Debug.Log("hello");
        Debug.LogError("world");
    }
}
