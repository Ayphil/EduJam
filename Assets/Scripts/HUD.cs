using Animancer;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int goldenCheckmarks = 0;

    [SerializeField] private GameObject Checkmark;
    [SerializeField] private AnimancerComponent CheckmarkBrain;
    [SerializeField] private AnimationClip CheckmarkAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetCheckmarks(Difficulty.DifficultyLevel level)
    {
        if(level == Difficulty.DifficultyLevel.Easy && level == Difficulty.DifficultyLevel.Medium)
        {
            goldenCheckmarks += 1;
        }
        else if (level == Difficulty.DifficultyLevel.Hard && level == Difficulty.DifficultyLevel.Hell)
        {
            goldenCheckmarks += 2;
        }

        CheckmarkBrain.Play(CheckmarkAnimation);
        Checkmark.GetComponentInChildren<TMP_Text>().text = goldenCheckmarks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
