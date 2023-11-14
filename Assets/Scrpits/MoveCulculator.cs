using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class MoveCulculator : MonoBehaviour
{
    private Vector3 headMove;
    private Vector3 handMove;
    private Vector3 tempHeadMove;
    private Vector3 tempRHandMove;
    private Vector3 tempLHandMove;

    public float headMoveAmount = 0f;
    public float rHandMoveAmount = 0f;
    public float lHandMoveAmount = 0f;
    private float initialHeadMoveAmount = 0f;
    private float initialRHandMoveAmount = 0f;
    private float initialLHandMoveAmount = 0f;

    private bool isHeadMove = false;
    private bool isRHandMove = false;
    private bool isLHandMove = false;
    private bool isHandStart = false;

    [SerializeField] private FingerKeyboardController fingerKeyboardController;
    [SerializeField] private KeyboardController KeyboardController;


    // Start is called before the first frame update
    void Start()
    {
        tempRHandMove = Vector3.zero;
        tempLHandMove = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (fingerKeyboardController.IsFinish || KeyboardController.IsFinish)
        {
            return;
        }

        if (isHeadMove)
        {
            headMoveAmount += Vector3.Distance(Camera.main.transform.position, tempHeadMove);
            Debug.Log($"headMove:{headMoveAmount}");
            tempHeadMove = Camera.main.transform.position;

            
        }


        if (isHandStart)
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out MixedRealityPose rPose))
            {
                if (isRHandMove)
                {
                    rHandMoveAmount += Vector3.Distance(rPose.Position, tempRHandMove);
                    Debug.Log($"rhandMove:{rHandMoveAmount}");
                    tempRHandMove = rPose.Position;
                }
                else
                {
                    isRHandMove = true;
                }
            }
            else
            {
                if (isRHandMove)
                {
                    isRHandMove = false;
                    tempRHandMove = Vector3.zero;
                }
            }

            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out MixedRealityPose lPose))
            {
                if (isLHandMove)
                {
                    lHandMoveAmount += Vector3.Distance(lPose.Position, tempLHandMove);
                    Debug.Log($"lhandMove:{lHandMoveAmount}");
                    tempLHandMove = lPose.Position;
                }
                else
                {
                    isLHandMove = true;
                }
            }
            else
            {
                if (isLHandMove)
                {
                    isLHandMove = false;
                    tempLHandMove = Vector3.zero;
                }
            }
        }
        
    }

    public void HeadMoveStart()
    {
        isHeadMove = true;
        Debug.Log($"isHeadMove:{isHeadMove}");
        tempHeadMove = Camera.main.transform.position;
    }

    public void HandMoveStart()
    {
        isHandStart = true;
    }
}
