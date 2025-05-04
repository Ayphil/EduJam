using Animancer;
using TMPro;
using UnityEngine;

public class MainMenuRessources : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public int goldenCheckmarks = 0;

    [SerializeField] public TMP_Text CheckmarkText;
    [SerializeField] public TMP_Text ScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ressources ressource = FindObjectOfType<Ressources>();
        if (ressource == null)
        {
            return;
        }


        goldenCheckmarks = ressource.goldenCheckmarks;
        CheckmarkText.text = goldenCheckmarks.ToString();
        score = (int)ressource.highScore;
        ScoreText.text = "Score max.: " +score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
