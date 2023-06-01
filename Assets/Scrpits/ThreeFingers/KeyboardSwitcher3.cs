using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSwitcher3 : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text keyboardName;
    [SerializeField] private GameObject fingerKeyboardController;
    [SerializeField] private GameObject charaDisplay;
    [SerializeField] private GameObject threeKeyboardController;
    [SerializeField] private GameObject threeKeyboard;

    public void SwitchKeyboard()
    {
        if (keyboardName.text == "Finger")
        {
            keyboardName.text = "Keyboard";
            if (fingerKeyboardController.activeSelf)
            {
                fingerKeyboardController.SetActive(false);
            }
            if (charaDisplay.activeSelf)
            {
                charaDisplay.SetActive(false);
            }
            if (!threeKeyboardController.activeSelf)
            {
                threeKeyboardController.SetActive(true);
            }
            if (!threeKeyboard.activeSelf)
            {
                threeKeyboard.SetActive(true);
            }
        }

        if (keyboardName.text == "Keyboard")
        {
            keyboardName.text = "Finger";

            if (!fingerKeyboardController.activeSelf)
            {
                fingerKeyboardController.SetActive(true);
            }
            if (!charaDisplay.activeSelf)
            {
                charaDisplay.SetActive(true);
            }
            if (threeKeyboardController.activeSelf)
            {
                threeKeyboardController.SetActive(false);
            }
            if (threeKeyboard.activeSelf)
            {
                threeKeyboard.SetActive(false);
            }
        }
    }
}
