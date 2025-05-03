using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/Difficulty", order = 1)]

public class Difficulty : ScriptableObject
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
        Hell
    }
    public DifficultyLevel difficultyLevel;

    public int amountOfDefinitions;

    public int maxAmountOfHints;

    public GameObject cardPositionPrefab;
}
