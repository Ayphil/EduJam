using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaddyThePad : MonoBehaviour
{
    [SerializeField] private Ressources ressources;

    [SerializeField] private GameObject paddyThePadTextBox;

    [TextArea(3, 10)]
    [SerializeField] private string TutorialText;

    [TextArea(3, 10)]
    [SerializeField] private List<string> cheeringTexts = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ressources = FindFirstObjectByType<Ressources>();
        if (!ressources.isFirstLaunch) { return; }

        paddyThePadTextBox.SetActive(true);

        paddyThePadTextBox.GetComponentInChildren<TMP_Text>().text = TutorialText;

        Tween.ShakeScale(paddyThePadTextBox.transform, Vector3.one*1.2f, 0.5f, 1f)
            .Chain(Tween.Delay(4f))
            .Chain(Tween.Alpha(paddyThePadTextBox.GetComponent<Image>(), 1, 0, 1f))
            .Group(Tween.Color(paddyThePadTextBox.GetComponentInChildren<TMP_Text>(), new Color(0f, 0f, 0f, 0f), 1f));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
