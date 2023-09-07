using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.IO;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class FingerKeyboardController : MonoBehaviour
{

    private const int charaNum = 46;

    private float touchThreshold;
    private float tipThreshold = 0.015f;
    private float knuckeleThreshold = 0.02f;
    private float resetThreshold = 0.05f;
    private float intervalTime = 0.5f;
    private float elapsedTime = 0f;
    private double taskTime;
    private int errorCounter = 0;
    private int wordsLength;
    private int inputTempNum = 0;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI questionDisplay;
    [SerializeField] private ExperimentPreparation experimentPreparation;
    [SerializeField] private TaskStart taskStart;
    [SerializeField] private QuestionWordsManager questionWordsManager;
    [SerializeField] private AudioSource touchSound;
    [SerializeField] private MoveCulculator moveCulculator;

    private bool isInterval = false;
    private bool[] isInputs = new bool[charaNum];
    private bool isDelete = true;
    private bool isDecision = true;
    private bool isFinish = false;
    

    private List<string> charaListA = new List<string>() { "あ", "い", "う", "え", "お" };
    private List<string> charaListK = new List<string>() { "か", "き", "く", "け", "こ" };
    private List<string> charaListS = new List<string>() { "さ", "し", "す", "せ", "そ" };
    private List<string> charaListT = new List<string>() { "た", "ち", "つ", "て", "と" };
    private List<string> charaListN = new List<string>() { "な", "に", "ぬ", "ね", "の" };
    private List<string> charaListH = new List<string>() { "は", "ひ", "ふ", "へ", "ほ" };
    private List<string> charaListM = new List<string>() { "ま", "み", "む", "め", "も" };
    private List<string> charaListY = new List<string>() { "や", "ゆ", "よ" };
    private List<string> charaListR = new List<string>() { "ら", "り", "る", "れ", "ろ" };
    private List<string> charaListW = new List<string>() { "わ", "を", "ん" };


    private string[] questionWords;

    public bool IsFinish
    {
        get { return isFinish; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        questionWords = questionWordsManager.QuestionWords;

        var qWords = string.Join("", questionWords);
        wordsLength = qWords.Length;
        Debug.Log($"wordslength:{wordsLength}");

        for (int i = 0; i < charaNum; i++)
        {
            isInputs[i] = false;
        }

        var qNum = UnityEngine.Random.Range(0, questionWords.Length);
        questionDisplay.text = questionWords[qNum];
        questionWords = questionWords.Where(x => x != questionWords[qNum]).ToArray();

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputField.text = "";
            inputTempNum = 0;
        }
#endif

        // OneCharaErase();
        if (inputField.text != "finish")
        {
            if (inputField.text.Length > questionDisplay.text.Length)
            {
                inputField.text = inputField.text.Remove(inputField.text.Length - 1, inputField.text.Length - questionDisplay.text.Length);
                errorCounter += inputField.text.Length - questionDisplay.text.Length;
                inputTempNum = questionDisplay.text.Length;
                Debug.Log($"error:{errorCounter}");

                if (inputField.text.Length > 0)
                {
                    for (int i = 0; i < inputField.text.Length; i++)
                    {
                        if (inputField.text[inputField.text.Length - 1] != questionDisplay.text[inputField.text.Length - 1])
                        {
                            inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
                            errorCounter += 1;
                            inputTempNum -= 1;
                            Debug.Log($"error:{errorCounter}");
                        }
                    }
                }
            }

            if (inputField.text.Length != inputTempNum)
            {
                inputTempNum += 1;

                if (inputField.text.Length > 0)
                {
                    if (inputField.text[inputField.text.Length - 1] != questionDisplay.text[inputField.text.Length - 1])
                    {
                        inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
                        errorCounter += 1;
                        inputTempNum -= 1;
                        Debug.Log($"error:{errorCounter}");
                    }
                }

            }

            TrueJudgement();
        }


        var temp = inputField.text;

        if (!isInterval)
        {
            InputController();
        }
        

        if (inputField.text != temp)
        {
            isInterval = true;
        }
        if (isInterval)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= intervalTime)
            {
                isInterval = false;
                elapsedTime = 0f;
            }
        }

    }

/*
    private void OneCharaErase()
    {
        // 1文字消去
        if (inputField.text == "")
        {
            return;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out MixedRealityPose leftDelete) &&
                HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightDelete))
        {
            if (Vector3.Distance(leftDelete.Position, rightDelete.Position) <= 0.02f && isDelete)
            {
                inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
                errorCounter += 1;
                Debug.Log($"error:{errorCounter}");
                isDelete = false;
            }
            else if (Vector3.Distance(leftDelete.Position, rightDelete.Position) >= 0.025f && !isDelete)
            {
                isDelete = true;
            }
        }
    }
*/

/*
    private void Decision()
    {
        // 決定
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out MixedRealityPose leftDecision) &&
                HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightDecision))
        {
            if (Vector3.Distance(leftDecision.Position, rightDecision.Position) <= 0.02f && isDecision)
            {
                TrueJudgement();
                isDecision = false;
            }
            else if (Vector3.Distance(leftDecision.Position, rightDecision.Position) >= 0.025f && !isDecision)
            {
                isDecision = true;
            }
        }
    }
*/
    // 回答判定
    private void TrueJudgement()
    {
        if (inputField.text == questionDisplay.text)
        {
            if (questionWords.Length == 0)
            {
                isFinish = true;
                inputField.text = "finish";
                Debug.Log($"Finish:{DateTime.Now}");
                taskTime = (DateTime.Now - taskStart.taskStartTime).TotalSeconds;
                Debug.Log($"taskTime:{taskTime}");
                Debug.Log($"error:{errorCounter}");
                double allWords = wordsLength + errorCounter;
                var wps = 60.0f * (allWords / taskTime);
                double errorLate = (errorCounter / allWords) * 100d;
                Debug.Log($"wps:{wps}");
                Debug.Log($"errorlate:{errorLate}");

                experimentPreparation.CsvSave(wordsLength, errorCounter, taskTime, moveCulculator.headMoveAmount, "FingerData");

                return;
            }

            inputTempNum = 0;
            inputField.text = "";

            var qNum = UnityEngine.Random.Range(0, questionWords.Length);
            questionDisplay.text = questionWords[qNum];
            questionWords = questionWords.Where(x => x != questionWords[qNum]).ToArray();
        }
    }


    // 左手子音
    private void InputController()
    {
        switch (experimentPreparation.currentInputType)
        {
            case ExperimentPreparation.InputType.leftVowel:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose RightPalm_a))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(RightPalm_a, charaListA, 0);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose RightPalm_k))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(RightPalm_k, charaListK, 5);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose RightPalm_s))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(RightPalm_s, charaListS, 10);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose RightPalm_t))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(RightPalm_t, charaListT, 15);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose RightPalm_n))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(RightPalm_n, charaListN, 20);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out MixedRealityPose RightPalm_h))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(RightPalm_h, charaListH, 25);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_m))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(RightPalm_m, charaListM, 30);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_y))
                {
                    touchThreshold = knuckeleThreshold;
                    ThreeInputCharacter(RightPalm_y, charaListY, 35);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_r))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(RightPalm_r, charaListR, 38);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_w))
                {
                    touchThreshold = knuckeleThreshold;
                    ThreeInputCharacter(RightPalm_w, charaListW, 43);
                }
                break;

            case ExperimentPreparation.InputType.rightVowel:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftPalm_a))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(leftPalm_a, charaListA, 0);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftPalm_k))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(leftPalm_k, charaListK, 5);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftPalm_s))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(leftPalm_s, charaListS, 10);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftPalm_t))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(leftPalm_t, charaListT, 15);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftPalm_n))
                {
                    touchThreshold = tipThreshold;
                    FiveInputCharacter(leftPalm_n, charaListN, 20);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Left, out MixedRealityPose leftPalm_h))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(leftPalm_h, charaListH, 25);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_m))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(leftPalm_m, charaListM, 30);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_y))
                {
                    touchThreshold = knuckeleThreshold;
                    ThreeInputCharacter(leftPalm_y, charaListY, 35);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_r))
                {
                    touchThreshold = knuckeleThreshold;
                    FiveInputCharacter(leftPalm_r, charaListR, 38);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_w))
                {
                    touchThreshold = knuckeleThreshold;
                    ThreeInputCharacter(leftPalm_w, charaListW, 43);
                }
                break;

            case ExperimentPreparation.InputType.leftRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist))
                {
                    if (leftWrist.Rotation.eulerAngles.y >= 0f && leftWrist.Rotation.eulerAngles.y < 90f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_a, charaListA, 0);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_k, charaListK, 5);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_s, charaListS, 10);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_t, charaListT, 15);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_n, charaListN, 20);
                        }
                    }

                    if (leftWrist.Rotation.eulerAngles.y > 270f && leftWrist.Rotation.eulerAngles.y < 360f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_h, charaListH, 25);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_m, charaListM, 30);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_y, charaListY, 35);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_r, charaListR, 38);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_w, charaListW, 43);
                        }
                    }
                }
                break;

            case ExperimentPreparation.InputType.rightRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_))
                {
                    if (leftWrist_.Rotation.eulerAngles.y > 270f && leftWrist_.Rotation.eulerAngles.y < 360f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_a, charaListA, 0);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_k, charaListK, 5);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_s, charaListS, 10);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_t, charaListT, 15);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_n, charaListN, 20);
                        }
                    }

                    if (leftWrist_.Rotation.eulerAngles.y >= 0f && leftWrist_.Rotation.eulerAngles.y < 90f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_h, charaListH, 25);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_m, charaListM, 30);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_y, charaListY, 35);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_r, charaListR, 38);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_w, charaListW, 43);
                        }
                    }
                }
                break;

            case ExperimentPreparation.InputType.upRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_up))
                {
                    if (leftWrist_up.Rotation.eulerAngles.x >= 270f && leftWrist_up.Rotation.eulerAngles.x < 330f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_a, charaListA, 0);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_k, charaListK, 5);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_s, charaListS, 10);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_t, charaListT, 15);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_n, charaListN, 20);
                        }
                    }

                    if (leftWrist_up.Rotation.eulerAngles.x >= 330f && leftWrist_up.Rotation.eulerAngles.x < 360f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_h, charaListH, 25);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_m, charaListM, 30);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_y, charaListY, 35);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_r, charaListR, 38);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_w, charaListW, 43);
                        }
                    }
                }
                break;

            case ExperimentPreparation.InputType.downRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_down))
                {
                    if (leftWrist_down.Rotation.eulerAngles.x >= 330f && leftWrist_down.Rotation.eulerAngles.x < 360f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_a, charaListA, 0);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_k, charaListK, 5);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_s, charaListS, 10);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_t, charaListT, 15);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            touchThreshold = tipThreshold;
                            FiveInputCharacter(leftRotPalm_n, charaListN, 20);
                        }
                    }

                    if (leftWrist_down.Rotation.eulerAngles.x >= 270f && leftWrist_down.Rotation.eulerAngles.x < 330f)
                    {
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_h, charaListH, 25);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_m, charaListM, 30);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_y, charaListY, 35);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            touchThreshold = knuckeleThreshold;
                            FiveInputCharacter(leftRotPalm_r, charaListR, 38);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            touchThreshold = knuckeleThreshold;
                            ThreeInputCharacter(leftRotPalm_w, charaListW, 43);
                        }
                    }
                }
                break;
        }

        
        
    }

    // 右手母音
    private void FiveInputCharacter(MixedRealityPose leftHandPoint, List<string> charaList, int startNum)
    {
        switch (experimentPreparation.currentInputType)
        {
            case ExperimentPreparation.InputType.leftVowel:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftPalm_5a))
                {
                    TouchAndInput(leftHandPoint, leftPalm_5a, charaList[0], startNum);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftPalm_5i))
                {
                    TouchAndInput(leftHandPoint, leftPalm_5i, charaList[1], startNum + 1);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftPalm_5u))
                {
                    TouchAndInput(leftHandPoint, leftPalm_5u, charaList[2], startNum + 2);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftPalm_5e))
                {
                    TouchAndInput(leftHandPoint, leftPalm_5e, charaList[3], startNum + 3);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftPalm_5o))
                {
                    TouchAndInput(leftHandPoint, leftPalm_5o, charaList[4], startNum + 4);
                }
                break;

            case ExperimentPreparation.InputType.rightVowel:
            case ExperimentPreparation.InputType.leftRotation:
            case ExperimentPreparation.InputType.rightRotation:
            case ExperimentPreparation.InputType.upRotation:
            case ExperimentPreparation.InputType.downRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightPalm_5a))
                {
                    TouchAndInput(leftHandPoint, rightPalm_5a, charaList[0], startNum);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightPalm_5i))
                {
                    TouchAndInput(leftHandPoint, rightPalm_5i, charaList[1], startNum + 1);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightPalm_5u))
                {
                    TouchAndInput(leftHandPoint, rightPalm_5u, charaList[2], startNum + 2);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightPalm_5e))
                {
                    TouchAndInput(leftHandPoint, rightPalm_5e, charaList[3], startNum + 3);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightPalm_5o))
                {
                    TouchAndInput(leftHandPoint, rightPalm_5o, charaList[4], startNum + 4);
                }
                break;
        }

    }

    // 右手母音　や行わ行
    private void ThreeInputCharacter(MixedRealityPose leftHandPoint, List<string> charaList, int startNum)
    {
        switch (experimentPreparation.currentInputType)
        {
            case ExperimentPreparation.InputType.leftVowel:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftPalm_3a))
                {
                    TouchAndInput(leftHandPoint, leftPalm_3a, charaList[0], startNum);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftPalm_3u))
                {
                    TouchAndInput(leftHandPoint, leftPalm_3u, charaList[1], startNum + 1);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftPalm_3o))
                {
                    TouchAndInput(leftHandPoint, leftPalm_3o, charaList[2], startNum + 2);
                }
                break;

            case ExperimentPreparation.InputType.rightVowel:
            case ExperimentPreparation.InputType.leftRotation:
            case ExperimentPreparation.InputType.rightRotation:
            case ExperimentPreparation.InputType.upRotation:
            case ExperimentPreparation.InputType.downRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightPalm_3a))
                {
                    TouchAndInput(leftHandPoint, rightPalm_3a, charaList[0], startNum);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightPalm_3u))
                {
                    TouchAndInput(leftHandPoint, rightPalm_3u, charaList[1], startNum + 1);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightPalm_3o))
                {
                    TouchAndInput(leftHandPoint, rightPalm_3o, charaList[2], startNum + 2);
                }
                break;
        }
    }

    // 接触判定
    private void TouchAndInput(MixedRealityPose right, MixedRealityPose left, string chara, int charaNum)
    {
        var handPointDistance = HandPointDistance(right, left);
        // Debug.Log(handPointDistance);
        if (handPointDistance > 0.001f && handPointDistance < touchThreshold && isInputs[charaNum])
        {
            if (experimentPreparation.isTouchSound)
            {
                touchSound.PlayOneShot(touchSound.clip);
                Debug.Log("touch");
            }
            
            inputField.text += chara;
            // Debug.Log(chara);
            isInputs[charaNum] = false;
            return;
        }
        else if (handPointDistance >= resetThreshold && !isInputs[charaNum])
        {
            isInputs[charaNum] = true;
            return;
        }
    }

    // 各点の距離
    private float HandPointDistance(MixedRealityPose right, MixedRealityPose left)
    {
        return Vector3.Distance(right.Position, left.Position);
    }
}