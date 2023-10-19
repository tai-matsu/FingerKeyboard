using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;


public class InputNumber : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshPro numChara;


    public void InputNum()
    {
        inputField.text += numChara.text;
    }
}
