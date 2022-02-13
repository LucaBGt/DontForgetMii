using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiiMakerGenderUI : MonoBehaviour
{
    public Button BackButton;
    public GameObject PleasePronouns;
    [Header("Input Fields")]
    public string Input1 = "They";
    public string Input2 = "Them";
    public string Input3 = "Theirs";
    public void SetInput1(string s)
    {
        Input1 = s;
        CheckIfPronounEmpty();
    }
    public void SetInput2(string s)
    {
        Input2 = s;
        CheckIfPronounEmpty();
    }
    public void SetInput3(string s)
    {
        Input3 = s;
        CheckIfPronounEmpty();
    }

    void CheckIfPronounEmpty()
    {
        if (Input1 == "" || Input2 == "" || Input3 == "")
        {
            BackButton.interactable = false;
            PleasePronouns.SetActive(true);
        }
        else
        {
            BackButton.interactable = true;
            PleasePronouns.SetActive(false);
            StaticEvents.ReplaceMiiPronouns.Invoke(Input1, Input2, Input3);
        }
    }
}
