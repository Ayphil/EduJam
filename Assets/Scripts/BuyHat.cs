using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyHat : MonoBehaviour
{

    [SerializeField] private TMP_Text checkmarkText;

    [SerializeField] Ressources ressources;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip errorClip;

    [SerializeField] private GameObject hatPrice1;
    [SerializeField] private Button hat1Button;
    [SerializeField] private Sprite hat1;

    [SerializeField] private GameObject hatPrice2;
    [SerializeField] private Button hat2Button;
    [SerializeField] private Sprite hat2;

    [SerializeField] private GameObject hatPrice3;
    [SerializeField] private Button hat3Button;
    [SerializeField] private Sprite hat3;

    [SerializeField] private GameObject hatPrice4;
    [SerializeField] private Button hat4Button;
    [SerializeField] private Sprite hat4;

    [SerializeField] private GameObject hatPrice5;
    [SerializeField] private Button hat5Button;
    [SerializeField] private Sprite hat5;

    [SerializeField] private GameObject hatPrice6;
    [SerializeField] private Button hat6Button;
    [SerializeField] private Sprite hat6;

    [SerializeField] private Image PaddyHat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ressources = FindFirstObjectByType<Ressources>();

        checkmarkText.text = ressources.goldenCheckmarks.ToString();

        hat1Button.onClick.AddListener(() => BuyHatButton(2));
        hat2Button.onClick.AddListener(() => BuyHatButton(5));
        hat3Button.onClick.AddListener(() => BuyHatButton(8));
        hat4Button.onClick.AddListener(() => BuyHatButton(20));
        hat5Button.onClick.AddListener(() => BuyHatButton(50));
        hat6Button.onClick.AddListener(() => BuyHatButton(150));

        CheckUnlockedHat();
    }

    // Update is called once per frame
    public void BuyHatButton(int price)
    {
        if (ressources.goldenCheckmarks < price)
        {
            source.PlayOneShot(errorClip);
            return;
        }

        ressources.goldenCheckmarks -= price;
        checkmarkText.text = ressources.goldenCheckmarks.ToString();

        switch (price)
        {
            case 2:
                ressources.hat1Unlocked = true;
                break;
            case 5:
                ressources.hat2Unlocked = true;
                break;
            case 8:
                ressources.hat3Unlocked = true;
                break;
            case 20:
                ressources.hat4Unlocked = true;
                break;
            case 50:
                ressources.hat5Unlocked = true;
                break;
            case 150:
                ressources.hat6Unlocked = true;
                break;
        }

        CheckUnlockedHat();
    }

    private void CheckUnlockedHat()
    {
        if (ressources.hat1Unlocked)
        {
            hat1Button.onClick.RemoveAllListeners();
            hat1Button.onClick.AddListener(() => EquipNewHat(hat1));
            hatPrice1.SetActive(false);
            // Unlock hat 1
        }
        if (ressources.hat2Unlocked)
        {
            hat2Button.onClick.RemoveAllListeners();
            hat2Button.onClick.AddListener(() => EquipNewHat(hat2));
            hatPrice2.SetActive(false);
            // Unlock hat 2
        }
        if (ressources.hat3Unlocked)
        {
            hat3Button.onClick.RemoveAllListeners();
            hat3Button.onClick.AddListener(() => EquipNewHat(hat3));
            hatPrice3.SetActive(false);
            // Unlock hat 3
        }
        if (ressources.hat4Unlocked)
        {
            hat4Button.onClick.RemoveAllListeners();
            hat4Button.onClick.AddListener(() => EquipNewHat(hat4));
            hatPrice4.SetActive(false);
            // Unlock hat 4
        }
        if (ressources.hat5Unlocked)
        {
            hat5Button.onClick.RemoveAllListeners();
            hat5Button.onClick.AddListener(() => EquipNewHat(hat5));
            hatPrice5.SetActive(false);
            // Unlock hat 5
        }
        if (ressources.hat6Unlocked)
        {
            hat6Button.onClick.RemoveAllListeners();
            hat6Button.onClick.AddListener(() => EquipNewHat(hat6));
            hatPrice6.SetActive(false);
            // Unlock hat 6
        }
    }

    private void EquipNewHat(Sprite sprite)
    {
        ressources.PaddyHat = sprite;

        if (ressources.PaddyHat != null)
        {
            PaddyHat.sprite = ressources.PaddyHat;
            PaddyHat.enabled = true;
        }
    }
}
