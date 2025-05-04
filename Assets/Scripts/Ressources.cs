using UnityEngine;

public class Ressources : MonoBehaviour
{
    [SerializeField] public int goldenCheckmarks;
    [SerializeField] public float highScore;

    [SerializeField] public Difficulty.DifficultyLevel difficultyLevel;

    [SerializeField] public bool isNormalUnlocked = false;
    [SerializeField] public bool isHardUnlocked = false;
    [SerializeField] public bool isHellUnlocked = false;
    [SerializeField] public bool isFirstLaunch = true;

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
