using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Input3X3Keyboard : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text chara;

    // •¶Žš“ü—Í
    public void TouchCharaInput()
    {
        inputField.text += chara.text;
    }
}
