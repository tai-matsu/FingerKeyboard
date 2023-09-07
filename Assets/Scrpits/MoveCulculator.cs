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
    private Vector3 tempHandMove;

    public float headMoveAmount = 0f;
    private float handMoveAmount = 0f;
    private float initialHeadMoveAmount = 0f;
    private float initialHandMoveAmount = 0f;

    private bool isHeadMove = false;

    [SerializeField] private FingerKeyboardController fingerKeyboardController;
    [SerializeField] private KeyboardController KeyboardController;


    // Start is called before the first frame update
    void Start()
    {
        
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
        


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out MixedRealityPose pose))
        {

        }
    }

    public void HeadMoveStart()
    {
        isHeadMove = true;
        Debug.Log($"isHeadMove:{isHeadMove}");
        tempHeadMove = Camera.main.transform.position;
    }
}
