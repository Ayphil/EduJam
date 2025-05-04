using System;
using Animancer;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] public float score = 0;
    [SerializeField] private int multiplier = 5;
    [SerializeField] private float comboStreak = 0;
    [SerializeField] public int goldenCheckmarks = 0;

    [SerializeField] public TMP_Text scoreText;
    [SerializeField] private GameObject Checkmark;
    [SerializeField] private AnimancerComponent CheckmarkBrain;
    [SerializeField] private AnimationClip CheckmarkAnimation;

    [SerializeField] public GameObject EndCheckmarkText;
    [SerializeField] public GameObject EndScoreText;

    [SerializeField] public Difficulty.DifficultyLevel difficultyLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetCheckmarks(Difficulty.DifficultyLevel level)
    {
        difficultyLevel = level;
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
            comboStreak += 1f;
        }
        score += (1000 * comboStreak + 1000)* 0.75f + (float)difficultyLevel*0.25f;
        score = (int)score;
        scoreText.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
