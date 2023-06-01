using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class CharaDisplayController3 : MonoBehaviour
{
    // Žq‰¹
    [SerializeField] private GameObject a_c;
    [SerializeField] private GameObject k;
    [SerializeField] private GameObject s;

    // •ê‰¹
    [SerializeField] private GameObject a_v;
    [SerializeField] private GameObject i;
    [SerializeField] private GameObject u;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharaDisplay();
    }

    private void CharaDisplay()
    {
        // Žq‰¹
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftPalm_a))
        {
            a_c.SetActive(true);
            a_c.transform.position = leftPalm_a.Position;
        }
        else
        {
            a_c.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftPalm_k))
        {
            k.SetActive(true);
            k.transform.position = leftPalm_k.Position;
        }
        else
        {
            k.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftPalm_s))
        {
            s.SetActive(true);
            s.transform.position = leftPalm_s.Position;
        }
        else
        {
            s.SetActive(false);
        }
        

        // •ê‰¹
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightPalm_a))
        {
            a_v.SetActive(true);
            a_v.transform.position = rightPalm_a.Position;
        }
        else
        {
            a_v.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightPalm_i))
        {
            i.SetActive(true);
            i.transform.position = rightPalm_i.Position;
        }
        else
        {
            i.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightPalm_u))
        {
            u.SetActive(true);
            u.transform.position = rightPalm_u.Position;
        }
        else
        {
            u.SetActive(false);
        }
    }
}
