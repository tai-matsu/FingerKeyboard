using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;


public class SphereController : MonoBehaviour
{
    [SerializeField] private GameObject sphere;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose tipPose))
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out MixedRealityPose distalPose))
            {
                var vec = tipPose.Position - distalPose.Position;

                sphere.transform.position = vec;
            }

        }
    }
}
