using System.Collections;
using System.Collections.Generic;
using System.Threading;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaddyThePad : MonoBehaviour
{
    [SerializeField] private Ressources ressources;

    [SerializeField] private GameObject paddyThePadTextBox;

    [TextArea(3, 10)]
    [SerializeField] private string TutorialText;

    [TextArea(3, 10)]
    [SerializeField] private List<string> cheeringTexts = new List<string>();

    [SerializeField] private float timeToNextInterruption = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ressources = FindFirstObjectByType<Ressources>();
        if (!ressources.isFirstLaunch) { return; }
        ressources.isFirstLaunch = false;
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
        if(SceneManager.GetActiveScene().buildIndex != 5)
        {
            return;
        }
        timeToNextInterruption -= Time.deltaTime;

        if (timeToNextInterruption <= 0f)
        {

            timeToNextInterruption = Random.Range(5f, 40f);
            Tween.UIAnchoredPositionX(this.GetComponent<RectTransform>(), 420f, 320f, 0.4f)
                .Chain(Tween.Rotation(this.transform, new Vector3(0, 0, -8f), 0.15f, 0f))
                .Chain(Tween.Rotation(this.transform, new Vector3(0, 0, 8f), 0.15f, 0f))
                .Chain(Tween.Rotation(this.transform, new Vector3(0, 0, 0), 0.1f, 0f))
                .ChainCallback(() => paddyThePadTextBox.SetActive(true))
                .Chain(Tween.ShakeScale(paddyThePadTextBox.transform, Vector3.one * 1.2f, 0.5f, 1f))
                .Chain(Tween.Delay(4f))
                .Chain(Tween.Alpha(paddyThePadTextBox.GetComponent<Image>(), 1, 1f))
                .Group(Tween.Color(paddyThePadTextBox.GetComponentInChildren<TMP_Text>(), new Color(0f, 0f, 0f, 0f), 1f))
                .Chain(Tween.UIAnchoredPositionX(this.GetComponent<RectTransform>(), 420f, 320f, 0.4f)
);

            paddyThePadTextBox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            paddyThePadTextBox.GetComponentInChildren<TMP_Text>().alpha = 1f;
            paddyThePadTextBox.SetActive(false);
        }
    }

    private IEnumerator PaddySpeakSequence()
    {
        Tween.PositionX(this.transform, -68, 0f, 0f, 0f);

        yield return new WaitForSeconds(0.5f);
    }
    public void ShowCheeringText()
    {


        paddyThePadTextBox.SetActive(true);
        paddyThePadTextBox.GetComponentInChildren<TMP_Text>().text = cheeringTexts[Random.Range(0, cheeringTexts.Count)];
        Tween.ShakeScale(paddyThePadTextBox.transform, Vector3.one * 1.2f, 0.5f, 1f)
            .Chain(Tween.Delay(4f))
            .Chain(Tween.Alpha(paddyThePadTextBox.GetComponent<Image>(), 1, 0, 1f))
            .Group(Tween.Color(paddyThePadTextBox.GetComponentInChildren<TMP_Text>(), new Color(0f, 0f, 0f, 0f), 1f));
    }
}
