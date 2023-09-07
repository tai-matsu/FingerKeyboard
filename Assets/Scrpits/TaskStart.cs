using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStart : MonoBehaviour
{
    [SerializeField] private GameObject startButton;

    public DateTime taskStartTime;

    public void TaskTimeCountStart()
    {
        
        taskStartTime = DateTime.Now;
        Debug.Log($"start:{taskStartTime}");
        startButton.SetActive(false);
    }
}
