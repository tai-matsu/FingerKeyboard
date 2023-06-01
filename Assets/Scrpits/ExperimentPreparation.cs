using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class ExperimentPreparation : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown inputMode;
    [SerializeField] private bool isCsv;
    [SerializeField] private string subjectName;
    

    public void CsvSave(int wordsLength, int errorCounter, double taskTime, string folder)
    {
        if (isCsv)
        {
            var fileName = DateTime.Now.ToString("MM_dd_HH_mm_ss");
            var inputName = inputMode.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            var sw = new StreamWriter(@$"D:\Matsusaki\FingerKeyboardData\{folder}\Task\{fileName}_{inputName}_{subjectName}.csv", false);

            // var sw = new StreamWriter(@$"D:\Matsusaki\FingerKeyboardData\FingerData\Task\{fileName}.csv", false);

            var wps = 60.0f * ((wordsLength + errorCounter) / taskTime);
            var errorLate = errorCounter / (wordsLength + errorCounter);
            string[] s1 = { taskTime.ToString(), errorCounter.ToString(), wps.ToString(), errorLate.ToString() };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
            sw.Close();
        }
        
    }
}
