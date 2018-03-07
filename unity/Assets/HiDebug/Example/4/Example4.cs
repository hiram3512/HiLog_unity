using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example4 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        HiDebug.EnableOnScreen(true);
    }

    private int _index;
    private float _time;
    private float _timeRate = 1f;
    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _timeRate)
        {
            _index++;
            _time = 0;
            if (_index % 10 == 0)
            {
                Debug.LogError(_index);
            }
            else if (_index % 3 == 0)
            {
                Debug.LogWarning(_index);
            }
            else
            {
                Debug.Log(_index);
            }
        }
    }
}