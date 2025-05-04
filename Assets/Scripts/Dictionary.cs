using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private List<Defintion> definitions = new List<Defintion>();
    [SerializeField] private List<Button> buttons = new List<Button>();

    [SerializeField] private TMP_Text hinttext;
    public void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => ShowDefinitions(button.gameObject.GetComponent<TMP_Text>().text));
        }
    }
    public void ShowDefinitions(string test)
    {
        test = test.Replace("<u>", "");
        Debug.Log(test);
        string hintsToShow = "";
        foreach (Defintion definition in definitions)
        {
            if (definition.Definition == test)
            {
                foreach (string hint in definition.Hints)
                {
                    hintsToShow += hint + "\n\n";
                }
            }
        }

        hinttext.text = hintsToShow;
    }


}
