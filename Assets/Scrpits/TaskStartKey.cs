using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskStartKey : MonoBehaviour
{

    [SerializeField] UnityEvent StartByKey;

    public DateTime taskStartTime;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("keyClicked");
            StartByKey?.Invoke();
        }
    }

   
    public void TaskTimeCountStart()
    {

        taskStartTime = DateTime.Now;
        Debug.Log($"start:{taskStartTime}");
    }
}
