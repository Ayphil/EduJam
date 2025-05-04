using UnityEngine;
using UnityEngine.UI;

public class Ressources : MonoBehaviour
{
    [SerializeField] public int goldenCheckmarks;
    [SerializeField] public float highScore;
    [SerializeField] public Sprite PaddyHat;

    [SerializeField] public Difficulty.DifficultyLevel difficultyLevel;

    [SerializeField] public bool isNormalUnlocked = false;
    [SerializeField] public bool isHardUnlocked = false;
    [SerializeField] public bool isHellUnlocked = false;
    [SerializeField] public bool isFirstLaunch = true;

    [SerializeField] public bool hat1Unlocked = false;
    [SerializeField] public bool hat2Unlocked = false;
    [SerializeField] public bool hat3Unlocked = false;
    [SerializeField] public bool hat4Unlocked = false;
    [SerializeField] public bool hat5Unlocked = false;
    [SerializeField] public bool hat6Unlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CheckForHighScore(float score)
    {
        if (score > highScore)
        {
            highScore = (int)score;
        }
    }


}
