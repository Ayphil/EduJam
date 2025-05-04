using UnityEngine;

public class Ressources : MonoBehaviour
{
    [SerializeField] public int goldenCheckmarks;
    [SerializeField] public int highScore;

    [SerializeField] public Difficulty.DifficultyLevel difficultyLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CheckForHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }


}
