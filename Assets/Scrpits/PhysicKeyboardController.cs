using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhysicKeyboardController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void Update()
    {
 /*       if (tempText != inputField.text)
        {
            tempText = inputField.text;
        }
*/

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inputField.text = inputField.text.Replace("3", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inputField.text = inputField.text.Replace("e", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inputField.text = inputField.text.Replace("3", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inputField.text = inputField.text.Replace("e", "");
            inputField.text += "��";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            inputField.text = inputField.text.Replace("6", "");
            inputField.text += "��";
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            inputField.text = inputField.text.Replace("t", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            inputField.text = inputField.text.Replace("g", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            inputField.text = inputField.text.Replace("h", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Asterisk))
        {
            inputField.text = inputField.text.Replace("g", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            inputField.text = inputField.text.Replace("h", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            inputField.text = inputField.text.Replace("x", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputField.text = inputField.text.Replace("d", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            inputField.text = inputField.text.Replace("r", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            inputField.text = inputField.text.Replace("d", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            inputField.text = inputField.text.Replace("r", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inputField.text = inputField.text.Replace("q", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputField.text = inputField.text.Replace("q", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inputField.text = inputField.text.Replace("z", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputField.text = inputField.text.Replace("q", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputField.text = inputField.text.Replace("z", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            inputField.text = inputField.text.Replace("u", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inputField.text = inputField.text.Replace("l", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inputField.text = inputField.text.Replace("l", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inputField.text = inputField.text.Replace("v", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inputField.text = inputField.text.Replace("l", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inputField.text = inputField.text.Replace("l", "");
            inputField.text += "��";
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            inputField.text = inputField.text.Replace("y", "");
            inputField.text += "��";
        }
        
        
 
    }
}


