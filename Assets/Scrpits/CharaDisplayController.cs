using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class CharaDisplayController : MonoBehaviour
{
    // 子音
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

    // 母音
    [SerializeField] private GameObject a_v;
    [SerializeField] private GameObject i;
    [SerializeField] private GameObject u;
    [SerializeField] private GameObject e;
    [SerializeField] private GameObject o;

    [SerializeField] private ExperimentPreparation experimentPreparation;

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
        switch (experimentPreparation.currentInputType)
        {
            case ExperimentPreparation.InputType.leftVowel:
                // 子音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose RightPalm_a))
                {
                    a_c.SetActive(true);
                    a_c.transform.position = RightPalm_a.Position;
                }
                else
                {
                    a_c.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose RightPalm_k))
                {
                    k.SetActive(true);
                    k.transform.position = RightPalm_k.Position;
                }
                else
                {
                    k.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose RightPalm_s))
                {
                    s.SetActive(true);
                    s.transform.position = RightPalm_s.Position;
                }
                else
                {
                    s.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose RightPalm_t))
                {
                    t.SetActive(true);
                    t.transform.position = RightPalm_t.Position;
                }
                else
                {
                    t.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose RightPalm_n))
                {
                    n.SetActive(true);
                    n.transform.position = RightPalm_n.Position;
                }
                else
                {
                    n.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out MixedRealityPose RightPalm_h))
                {
                    h.SetActive(true);
                    h.transform.position = RightPalm_h.Position;
                }
                else
                {
                    h.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_m))
                {
                    m.SetActive(true);
                    m.transform.position = RightPalm_m.Position;
                }
                else
                {
                    m.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_y))
                {
                    y.SetActive(true);
                    y.transform.position = RightPalm_y.Position;
                }
                else
                {
                    y.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_r))
                {
                    r.SetActive(true);
                    r.transform.position = RightPalm_r.Position;
                }
                else
                {
                    r.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out MixedRealityPose RightPalm_w))
                {
                    w.SetActive(true);
                    w.transform.position = RightPalm_w.Position;
                }
                else
                {
                    w.SetActive(false);
                }

                // 母音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose LeftPalm_a))
                {
                    a_v.SetActive(true);
                    a_v.transform.position = LeftPalm_a.Position;
                }
                else
                {
                    a_v.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose LeftPalm_i))
                {
                    i.SetActive(true);
                    i.transform.position = LeftPalm_i.Position;
                }
                else
                {
                    i.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose LeftPalm_u))
                {
                    u.SetActive(true);
                    u.transform.position = LeftPalm_u.Position;
                }
                else
                {
                    u.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose LeftPalm_e))
                {
                    e.SetActive(true);
                    e.transform.position = LeftPalm_e.Position;
                }
                else
                {
                    e.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose LeftPalm_o))
                {
                    o.SetActive(true);
                    o.transform.position = LeftPalm_o.Position;
                }
                else
                {
                    o.SetActive(false);
                }
                break;
        
            case ExperimentPreparation.InputType.rightVowel:
                // 子音
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

                // 母音
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
                break;
        
            case ExperimentPreparation.InputType.leftRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist))
                {
                    if (leftWrist.Rotation.eulerAngles.y >= 0f && leftWrist.Rotation.eulerAngles.y < 90f)
                    {
                        h.SetActive(false);
                        m.SetActive(false);
                        y.SetActive(false);
                        r.SetActive(false);
                        w.SetActive(false);

                        // 子音
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            a_c.SetActive(true);
                            a_c.transform.position = leftRotPalm_a.Position;
                        }
                        else
                        {
                            a_c.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            k.SetActive(true);
                            k.transform.position = leftRotPalm_k.Position;
                        }
                        else
                        {
                            k.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            s.SetActive(true);
                            s.transform.position = leftRotPalm_s.Position;
                        }
                        else
                        {
                            s.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            t.SetActive(true);
                            t.transform.position = leftRotPalm_t.Position;
                        }
                        else
                        {
                            t.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            n.SetActive(true);
                            n.transform.position = leftRotPalm_n.Position;
                        }
                        else
                        {
                            n.SetActive(false);
                        }
                    }

                    if (leftWrist.Rotation.eulerAngles.y > 270f && leftWrist.Rotation.eulerAngles.y < 360f)
                    {
                        a_c.SetActive(false);
                        k.SetActive(false);
                        s.SetActive(false);
                        t.SetActive(false);
                        n.SetActive(false);

                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            h.SetActive(true);
                            h.transform.position = leftRotPalm_h.Position;
                        }
                        else
                        {
                            h.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            m.SetActive(true);
                            m.transform.position = leftRotPalm_m.Position;
                        }
                        else
                        {
                            m.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            y.SetActive(true);
                            y.transform.position = leftRotPalm_y.Position;
                        }
                        else
                        {
                            y.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            r.SetActive(true);
                            r.transform.position = leftRotPalm_r.Position;
                        }
                        else
                        {
                            r.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            w.SetActive(true);
                            w.transform.position = leftRotPalm_w.Position;
                        }
                        else
                        {
                            w.SetActive(false);
                        }
                    }
                } 

                // 母音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightRotPalm_a))
                {
                    a_v.SetActive(true);
                    a_v.transform.position = rightRotPalm_a.Position;
                }
                else
                {
                    a_v.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightRotPalm_i))
                {
                    i.SetActive(true);
                    i.transform.position = rightRotPalm_i.Position;
                }
                else
                {
                    i.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightRotPalm_u))
                {
                    u.SetActive(true);
                    u.transform.position = rightRotPalm_u.Position;
                }
                else
                {
                    u.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightRotPalm_e))
                {
                    e.SetActive(true);
                    e.transform.position = rightRotPalm_e.Position;
                }
                else
                {
                    e.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightRotPalm_o))
                {
                    o.SetActive(true);
                    o.transform.position = rightRotPalm_o.Position;
                }
                else
                {
                    o.SetActive(false);
                }
                break;

            case ExperimentPreparation.InputType.rightRotation:
                // 子音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_))
                {
                    if (leftWrist_.Rotation.eulerAngles.y > 270f && leftWrist_.Rotation.eulerAngles.y < 360f)
                    {
                        h.SetActive(false);
                        m.SetActive(false);
                        y.SetActive(false);
                        r.SetActive(false);
                        w.SetActive(false);
                        
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            a_c.SetActive(true);
                            a_c.transform.position = leftRotPalm_a.Position;
                        }
                        else
                        {
                            a_c.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            k.SetActive(true);
                            k.transform.position = leftRotPalm_k.Position;
                        }
                        else
                        {
                            k.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            s.SetActive(true);
                            s.transform.position = leftRotPalm_s.Position;
                        }
                        else
                        {
                            s.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            t.SetActive(true);
                            t.transform.position = leftRotPalm_t.Position;
                        }
                        else
                        {
                            t.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            n.SetActive(true);
                            n.transform.position = leftRotPalm_n.Position;
                        }
                        else
                        {
                            n.SetActive(false);
                        }
                    }

                    if (leftWrist_.Rotation.eulerAngles.y >= 0f && leftWrist_.Rotation.eulerAngles.y < 90f)
                    {
                        a_c.SetActive(false);
                        k.SetActive(false);
                        s.SetActive(false);
                        t.SetActive(false);
                        n.SetActive(false);

                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            h.SetActive(true);
                            h.transform.position = leftRotPalm_h.Position;
                        }
                        else
                        {
                            h.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            m.SetActive(true);
                            m.transform.position = leftRotPalm_m.Position;
                        }
                        else
                        {
                            m.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            y.SetActive(true);
                            y.transform.position = leftRotPalm_y.Position;
                        }
                        else
                        {
                            y.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            r.SetActive(true);
                            r.transform.position = leftRotPalm_r.Position;
                        }
                        else
                        {
                            r.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            w.SetActive(true);
                            w.transform.position = leftRotPalm_w.Position;
                        }
                        else
                        {
                            w.SetActive(false);
                        }
                    }
                }

                // 母音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightRotPalm_a_))
                {
                    a_v.SetActive(true);
                    a_v.transform.position = rightRotPalm_a_.Position;
                }
                else
                {
                    a_v.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightRotPalm_i_))
                {
                    i.SetActive(true);
                    i.transform.position = rightRotPalm_i_.Position;
                }
                else
                {
                    i.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightRotPalm_u_))
                {
                    u.SetActive(true);
                    u.transform.position = rightRotPalm_u_.Position;
                }
                else
                {
                    u.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightRotPalm_e_))
                {
                    e.SetActive(true);
                    e.transform.position = rightRotPalm_e_.Position;
                }
                else
                {
                    e.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightRotPalm_o_))
                {
                    o.SetActive(true);
                    o.transform.position = rightRotPalm_o_.Position;
                }
                else
                {
                    o.SetActive(false);
                }
                break;

            case ExperimentPreparation.InputType.upRotation:
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_up))
                {
                    Debug.Log(leftWrist_up.Rotation.eulerAngles.x);
                    if (leftWrist_up.Rotation.eulerAngles.x >= 270f && leftWrist_up.Rotation.eulerAngles.x < 330f)
                    {
                        h.SetActive(false);
                        m.SetActive(false);
                        y.SetActive(false);
                        r.SetActive(false);
                        w.SetActive(false);

                        // 子音
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            a_c.SetActive(true);
                            a_c.transform.position = leftRotPalm_a.Position;
                        }
                        else
                        {
                            a_c.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            k.SetActive(true);
                            k.transform.position = leftRotPalm_k.Position;
                        }
                        else
                        {
                            k.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            s.SetActive(true);
                            s.transform.position = leftRotPalm_s.Position;
                        }
                        else
                        {
                            s.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            t.SetActive(true);
                            t.transform.position = leftRotPalm_t.Position;
                        }
                        else
                        {
                            t.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            n.SetActive(true);
                            n.transform.position = leftRotPalm_n.Position;
                        }
                        else
                        {
                            n.SetActive(false);
                        }
                    }

                    if (leftWrist_up.Rotation.eulerAngles.x >= 330f && leftWrist_up.Rotation.eulerAngles.x < 360f)
                    {
                        a_c.SetActive(false);
                        k.SetActive(false);
                        s.SetActive(false);
                        t.SetActive(false);
                        n.SetActive(false);

                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            h.SetActive(true);
                            h.transform.position = leftRotPalm_h.Position;
                        }
                        else
                        {
                            h.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            m.SetActive(true);
                            m.transform.position = leftRotPalm_m.Position;
                        }
                        else
                        {
                            m.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            y.SetActive(true);
                            y.transform.position = leftRotPalm_y.Position;
                        }
                        else
                        {
                            y.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            r.SetActive(true);
                            r.transform.position = leftRotPalm_r.Position;
                        }
                        else
                        {
                            r.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            w.SetActive(true);
                            w.transform.position = leftRotPalm_w.Position;
                        }
                        else
                        {
                            w.SetActive(false);
                        }
                    }
                }

                // 母音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightUpPalm_a))
                {
                    a_v.SetActive(true);
                    a_v.transform.position = rightUpPalm_a.Position;
                }
                else
                {
                    a_v.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightUpPalm_i))
                {
                    i.SetActive(true);
                    i.transform.position = rightUpPalm_i.Position;
                }
                else
                {
                    i.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightUpPalm_u))
                {
                    u.SetActive(true);
                    u.transform.position = rightUpPalm_u.Position;
                }
                else
                {
                    u.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightUpPalm_e))
                {
                    e.SetActive(true);
                    e.transform.position = rightUpPalm_e.Position;
                }
                else
                {
                    e.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightUpPalm_o))
                {
                    o.SetActive(true);
                    o.transform.position = rightUpPalm_o.Position;
                }
                else
                {
                    o.SetActive(false);
                }
                break;

            case ExperimentPreparation.InputType.downRotation:
                // 子音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose leftWrist_down))
                {
                    if (leftWrist_down.Rotation.eulerAngles.x >= 330f && leftWrist_down.Rotation.eulerAngles.x < 360f)
                    {
                        h.SetActive(false);
                        m.SetActive(false);
                        y.SetActive(false);
                        r.SetActive(false);
                        w.SetActive(false);

                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_a))
                        {
                            a_c.SetActive(true);
                            a_c.transform.position = leftRotPalm_a.Position;
                        }
                        else
                        {
                            a_c.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_k))
                        {
                            k.SetActive(true);
                            k.transform.position = leftRotPalm_k.Position;
                        }
                        else
                        {
                            k.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_s))
                        {
                            s.SetActive(true);
                            s.transform.position = leftRotPalm_s.Position;
                        }
                        else
                        {
                            s.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_t))
                        {
                            t.SetActive(true);
                            t.transform.position = leftRotPalm_t.Position;
                        }
                        else
                        {
                            t.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_n))
                        {
                            n.SetActive(true);
                            n.transform.position = leftRotPalm_n.Position;
                        }
                        else
                        {
                            n.SetActive(false);
                        }
                    }

                    if (leftWrist_down.Rotation.eulerAngles.x >= 270f && leftWrist_down.Rotation.eulerAngles.x < 330f)
                    {
                        a_c.SetActive(false);
                        k.SetActive(false);
                        s.SetActive(false);
                        t.SetActive(false);
                        n.SetActive(false);

                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out MixedRealityPose leftRotPalm_h))
                        {
                            h.SetActive(true);
                            h.transform.position = leftRotPalm_h.Position;
                        }
                        else
                        {
                            h.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose leftRotPalm_m))
                        {
                            m.SetActive(true);
                            m.transform.position = leftRotPalm_m.Position;
                        }
                        else
                        {
                            m.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out MixedRealityPose leftRotPalm_y))
                        {
                            y.SetActive(true);
                            y.transform.position = leftRotPalm_y.Position;
                        }
                        else
                        {
                            y.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out MixedRealityPose leftRotPalm_r))
                        {
                            r.SetActive(true);
                            r.transform.position = leftRotPalm_r.Position;
                        }
                        else
                        {
                            r.SetActive(false);
                        }
                        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out MixedRealityPose leftRotPalm_w))
                        {
                            w.SetActive(true);
                            w.transform.position = leftRotPalm_w.Position;
                        }
                        else
                        {
                            w.SetActive(false);
                        }
                    }
                }

                // 母音
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out MixedRealityPose rightDownPalm_a_))
                {
                    a_v.SetActive(true);
                    a_v.transform.position = rightDownPalm_a_.Position;
                }
                else
                {
                    a_v.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose rightDownPalm_i_))
                {
                    i.SetActive(true);
                    i.transform.position = rightDownPalm_i_.Position;
                }
                else
                {
                    i.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out MixedRealityPose rightDownPalm_u_))
                {
                    u.SetActive(true);
                    u.transform.position = rightDownPalm_u_.Position;
                }
                else
                {
                    u.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out MixedRealityPose rightDownPalm_e_))
                {
                    e.SetActive(true);
                    e.transform.position = rightDownPalm_e_.Position;
                }
                else
                {
                    e.SetActive(false);
                }
                if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out MixedRealityPose rightDownPalm_o_))
                {
                    o.SetActive(true);
                    o.transform.position = rightDownPalm_o_.Position;
                }
                else
                {
                    o.SetActive(false);
                }
                break;
        }
    }
}
