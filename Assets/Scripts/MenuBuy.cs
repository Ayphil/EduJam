using Animancer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBuy : MonoBehaviour
{

    [SerializeField] private MainMenuRessources mainMenuRessources;
    [SerializeField] private Ressources ressources;
    [SerializeField] private Button easyButton;

    [SerializeField] private int normalCost = 2;
    [SerializeField] private Button normalDifficultyButton;
    [SerializeField] private AnimancerComponent normalBrain;
    [SerializeField] private AnimationClip normalDifficultyAnimation;
    [SerializeField] private GameObject normalPriceText;

    [SerializeField] private int hardCost = 5;
    [SerializeField] private Button hardDifficultyButton;
    [SerializeField] private AnimancerComponent hardBrain;
    [SerializeField] private AnimationClip hardDifficultyAnimation;
    [SerializeField] private GameObject hardPriceText;

    [SerializeField] private int hellCost = 15;
    [SerializeField] private Button hellDifficultyButton;
    [SerializeField] private AnimancerComponent hellBrain;
    [SerializeField] private GameObject hellPriceText;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip errorClip;

    [SerializeField] private AudioClip succesfulUnclip;

    private void Start()
    {
        ressources = FindFirstObjectByType<Ressources>();

        if(ressources == null)
        {
            Debug.LogError("Ressources not found");
        }

        normalDifficultyButton.onClick.AddListener(() => OnBuyDifficulty(0));
        hardDifficultyButton.onClick.AddListener(() => OnBuyDifficulty(1));
        hellDifficultyButton.onClick.AddListener(() => OnBuyDifficulty(2));

        CheckForUnlocked();
    }
    public void OnBuyDifficulty(int difficultyLevel)
    {
        int checkmarkCost = 0;
        switch (difficultyLevel)
        {
            case 0:
                checkmarkCost = normalCost;
                break;
            case 1:
                checkmarkCost = hardCost;
                break;
            case 2:
                checkmarkCost = hellCost;
                break;
        }
        if (mainMenuRessources == null || checkmarkCost > mainMenuRessources.goldenCheckmarks)
        {
            source.PlayOneShot(errorClip);
            return;
        }
        source.PlayOneShot(succesfulUnclip);

        mainMenuRessources.goldenCheckmarks -= checkmarkCost;
        mainMenuRessources.CheckmarkText.text = mainMenuRessources.goldenCheckmarks.ToString();
        switch (difficultyLevel)
        {
            case 0:
                normalBrain.Play(normalDifficultyAnimation);
                normalDifficultyButton.onClick.RemoveAllListeners();
                normalDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Medium));
                ressources.isNormalUnlocked = true;
                normalPriceText.SetActive(false);
                break;
            case 1:
                hardBrain.Play(hardDifficultyAnimation);
                hardDifficultyButton.onClick.RemoveAllListeners();
                hardDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Hard));
                ressources.isHardUnlocked = true;
                hardPriceText.SetActive(false);
                break;
            case 2:
                hellBrain.Play(hardDifficultyAnimation);
                hellDifficultyButton.onClick.RemoveAllListeners();
                hellDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Hell));
                ressources.isHellUnlocked = true;
                hellPriceText.SetActive(false);
                break;
        }
    }

    public void CheckForUnlocked()
    {
        easyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Easy));
        if (ressources.isNormalUnlocked)
        {
            normalBrain.Play(normalDifficultyAnimation);
            normalDifficultyButton.onClick.RemoveAllListeners();
            normalDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Medium));
            ressources.isNormalUnlocked = true;
            normalPriceText.SetActive(false);
        }
        if (ressources.isHardUnlocked)
        {
            hardBrain.Play(hardDifficultyAnimation);
            hardDifficultyButton.onClick.RemoveAllListeners();
            hardDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Hard));
            ressources.isHardUnlocked = true;
            hardPriceText.SetActive(false);
        }
        if (ressources.isHellUnlocked)
        {
            hellBrain.Play(hardDifficultyAnimation);
            hellDifficultyButton.onClick.RemoveAllListeners();
            hellDifficultyButton.onClick.AddListener(() => PlayDifficulty(Difficulty.DifficultyLevel.Hell));
            ressources.isHellUnlocked = true;
            hellPriceText.SetActive(false);
        }
    }

    public void PlayDifficulty(Difficulty.DifficultyLevel level)
    {
        ressources.difficultyLevel = level;
        SceneManager.LoadScene(5);
    }
}
