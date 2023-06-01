using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class CharaDisplayController : MonoBehaviour
{
    // Žq‰¹
    [SerializeField] private GameObject a_c;
    [SerializeField] private GameObject k;
    [SerializeField] private GameObject s;
    [SerializeField] private GameObject t;
    [SerializeField] private GameObject n;
    [SerializeField] private GameObject h;
    [SerializeField] private GameObject m;
    [SerializeField] private GameObject y;
    [SerializeField] private GameObject r;
    [SerializeField] private GameObject w;

    // •ê‰¹
    [SerializeField] private GameObject a_v;
    [SerializeField] private GameObject i;
    [SerializeField] private GameObject u;
    [SerializeField] private GameObject e;
    [SerializeField] private GameObject o;


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
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftPalm_t))
        {
            t.SetActive(true);
            t.transform.position = leftPalm_t.Position;
        }
        else
        {
            t.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftPalm_n))
        {
            n.SetActive(true);
            n.transform.position = leftPalm_n.Position;
        }
        else
        {
            n.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Left, out MixedRealityPose leftPalm_h))
        {
            h.SetActive(true);
            h.transform.position = leftPalm_h.Position;
        }
        else
        {
            h.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_m))
        {
            m.SetActive(true);
            m.transform.position = leftPalm_m.Position;
        }
        else
        {
            m.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_y))
        {
            y.SetActive(true);
            y.transform.position = leftPalm_y.Position;
        }
        else
        {
            y.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_r))
        {
            r.SetActive(true);
            r.transform.position = leftPalm_r.Position;
        }
        else
        {
            r.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Left, out MixedRealityPose leftPalm_w))
        {
            w.SetActive(true);
            w.transform.position = leftPalm_w.Position;
        }
        else
        {
            w.SetActive(false);
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
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightPalm_e))
        {
            e.SetActive(true);
            e.transform.position = rightPalm_e.Position;
        }
        else
        {
            e.SetActive(false);
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightPalm_o))
        {
            o.SetActive(true);
            o.transform.position = rightPalm_o.Position;
        }
        else
        {
            o.SetActive(false);
        }
    }
}
