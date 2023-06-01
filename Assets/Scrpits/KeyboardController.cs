using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

public class KeyboardController : MonoBehaviour
{
    private float touchThreshold;
    private float tipThreshold = 0.015f;
    private float knuckeleThreshold = 0.02f;
    private float resetThreshold = 0.05f;
    private float intervalTime = 0.5f;
    private float elapsedTime = 0f;
    private double taskTime;
    private int errorCounter = 0;
    private int wordsLength;

    [SerializeField] private TextMeshProUGUI questionDisplay;
    [SerializeField] private Interactable startButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Interactable deleteInput;
    [SerializeField] private Interactable decisionInput;
    [SerializeField] private ExperimentPreparation experimentPreparation;
    [SerializeField] private TaskStart taskStart;
    [SerializeField] private QuestionWordsManager questionWordsManager;

    private string[] questionWords;

    // Start is called before the first frame update
    void Start()
    {
        questionWords = questionWordsManager.questionWords;

        // ‘“ü—Í”
        var qWords = string.Join("", questionWords);
        wordsLength = qWords.Length;
        Debug.Log($"wordslength:{wordsLength}");

        // –â‘è•\Ž¦•–â‘èƒŠƒXƒg‚©‚çíœ
        var qNum = UnityEngine.Random.Range(0, questionWords.Length);
        questionDisplay.text = questionWords[qNum];
        questionWords = questionWords.Where(x => x != questionWords[qNum]).ToArray();

        deleteInput.OnClick.AddListener(OneCharaErase);
        decisionInput.OnClick.AddListener(Decision);

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputField.text = "";
        }
#endif

    }

    private void OnDestroy()
    {
        deleteInput.OnClick.RemoveAllListeners();
        decisionInput.OnClick.RemoveAllListeners();
    }


    public void OneCharaErase()
    {
        // 1•¶ŽšÁ‹Ž
        if (inputField.text == "")
        {
            return;
        }

        inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
        errorCounter += 1;
        Debug.Log($"error:{errorCounter}");
    }

    public void Decision()
    {
        // Œˆ’è        
        TrueJudgement();
        
    }

    // ‰ñ“š”»’è
    private void TrueJudgement()
    {
        if (inputField.text == questionDisplay.text)
        {
            if (questionWords.Length == 0)
            {

                inputField.text = "finish";
                Debug.Log($"Finish:{DateTime.Now}");
                taskTime = (DateTime.Now - taskStart.taskStartTime).TotalSeconds;
                Debug.Log($"taskTime:{taskTime}");
                Debug.Log($"error:{errorCounter}");
                double allWords = wordsLength + errorCounter;
                var wps = 60.0f * (allWords / taskTime);
                double errorRate = (errorCounter / allWords) * 100d;
                Debug.Log($"words:{wordsLength + errorCounter}");
                Debug.Log($"wps:{wps}");
                Debug.Log($"errorlate:{errorRate}");

                experimentPreparation.CsvSave(wordsLength, errorCounter, taskTime, "KeyboardData");
                return;
            }

            inputField.text = "";

            var qNum = UnityEngine.Random.Range(0, questionWords.Length);
            questionDisplay.text = questionWords[qNum];
            questionWords = questionWords.Where(x => x != questionWords[qNum]).ToArray();
        }
    }

}

