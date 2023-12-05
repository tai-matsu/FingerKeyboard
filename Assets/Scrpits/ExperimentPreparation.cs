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
    [SerializeField] private GameObject charaDisplay;

    public bool isFinger;
    public InputType currentInputType = InputType.rightVowel;
    public bool isTouchSound;
    public bool isCharaDisplay;

    public enum InputType
    {
        leftVowel,
        rightVowel,
        threeFinger,
        leftRotation,
        rightRotation,
        upRotation,
        downRotation
    }

    private void Start()
    {
        if (isCharaDisplay)
        {
            charaDisplay.SetActive(true);
        }
        else
        {
            charaDisplay.SetActive(false);
        }
    }

    public void CsvSave(int wordsLength, int errorCounter, double taskTime, string folder)
    {
        if (isCsv)
        {
            var fileName = DateTime.Now.ToString("MM_dd_HH_mm_ss");
            var inputName = inputMode.GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
            using var sw = new StreamWriter(@$"D:\Matsusaki\FingerKeyboardData\{folder}\Task\{fileName}_{inputName}_{subjectName}.csv", false);

            // var sw = new StreamWriter(@$"D:\Matsusaki\FingerKeyboardData\FingerData\Task\{fileName}.csv", false);

            double wps = 60.0d * ((wordsLength + errorCounter) / taskTime);
            double errorLate = 100.0d * errorCounter / (wordsLength + errorCounter);
            string[] s1 = { taskTime.ToString(), errorCounter.ToString(), wps.ToString(), errorLate.ToString() };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
            sw.Close();
        }
        
    }
}
