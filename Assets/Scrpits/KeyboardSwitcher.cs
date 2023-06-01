using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject fingerTools;
    [SerializeField] private GameObject keyboardTools;
    [SerializeField] private TMP_Dropdown inputMode;


    private void Start()
    {
        inputMode.onValueChanged.AddListener(delegate
        {
            SwitchKeyboard();
        });
    }

    public void SwitchKeyboard()
    {
        Debug.Log("switch");

        if (inputMode.value == 0)
        {
            inputMode.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Finger";

            if (!fingerTools.activeSelf)
            {
                fingerTools.SetActive(true);
            }

            if (keyboardTools.activeSelf)
            {
                keyboardTools.SetActive(false);
            }

        }

        if (inputMode.value == 1)
        {
            inputMode.GetComponentInChildren<TextMeshProUGUI>().text = "Keyboard";
            if (fingerTools.activeSelf)
            {
                fingerTools.SetActive(false);
            }
           
            if (!keyboardTools.activeSelf)
            {
                keyboardTools.SetActive(true);
            }
            
        }

    }
}
