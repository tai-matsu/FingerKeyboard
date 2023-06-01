using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionWordsManager : MonoBehaviour
{
    // private string[] questionWords = { "‚¨‚â‚Â", "‚³‚©‚È" };
    private string[] questionWords = { "‚¨‚â‚Â", "‚³‚©‚È", "‚ ‚¢‚·", "‚Ý‚©‚ñ", "‚æ‚±‚Í‚Ü", "‚¢‚­‚ç", "‚©‚è‚ñ‚Æ‚¤", "‚Ó‚Æ‚ñ", "‚¯‚¢‚½‚¢", "‚Â‚Ý‚«" };

    public string[] QuestionWords
    {
        get
        {
            return questionWords;
        }
    }
}
