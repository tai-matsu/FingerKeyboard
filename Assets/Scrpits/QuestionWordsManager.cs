using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionWordsManager : MonoBehaviour
{
    // private string[] questionWords = { "�����", "������" };
    // private string[] questionWords = { "�����", "������", "������", "�݂���", "�悱�͂�", "������", "�����Ƃ�", "�ӂƂ�", "��������", "�݂�" };
    private string[] questionWords = { "������", "����", "�����", "������", "���Ȃ�" };

    public string[] QuestionWords
    {
        get
        {
            return questionWords;
        }
    }
}
