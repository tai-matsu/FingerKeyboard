using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputKeyboard : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text chara;

    // ��������
    public void TouchCharaInput()
    {
        inputField.text += chara.text;
    }
}
