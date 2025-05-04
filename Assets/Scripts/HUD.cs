using Animancer;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] private int multiplier = 2;
    [SerializeField] private int comboStreak = 2;
    [SerializeField] public int goldenCheckmarks = 0;

    [SerializeField] public TMP_Text scoreText;
    [SerializeField] private GameObject Checkmark;
    [SerializeField] private AnimancerComponent CheckmarkBrain;
    [SerializeField] private AnimationClip CheckmarkAnimation;

    [SerializeField] public GameObject EndCheckmarkText;
    [SerializeField] public GameObject EndScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetCheckmarks(Difficulty.DifficultyLevel level)
    {
        if (level == Difficulty.DifficultyLevel.Easy || level == Difficulty.DifficultyLevel.Medium)
        {
            goldenCheckmarks += 1;
        }
        else if (level == Difficulty.DifficultyLevel.Hard || level == Difficulty.DifficultyLevel.Hell)
        {
            goldenCheckmarks += 2;
        }

        CheckmarkBrain.Play(CheckmarkAnimation);
        Checkmark.GetComponentInChildren<TMP_Text>().text = goldenCheckmarks.ToString();
    }

    public void AddPoints(int interval, int flippedCardSum)
    {

        if (interval == 0)
        {
            comboStreak += 1;
        }
        score += ((multiplier / (2 * flippedCardSum)) * comboStreak) * score + 1000;
        scoreText.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
