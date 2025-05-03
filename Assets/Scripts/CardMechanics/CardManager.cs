using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] List<Defintion> definitions = new List<Defintion>();

    [SerializeField] List<Difficulty> difficulties = new List<Difficulty>();

    [SerializeField] private Difficulty.DifficultyLevel difficultyLevel;

    [SerializeField] private int AmountOfDefintions = 0;

    [SerializeField] private int MaxAmountOfHints = 0;

    [SerializeField] private List<Defintion> currentDefinitions = new List<Defintion>();

    [SerializeField] private List<Card> CurrentCards = new List<Card>();

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private GameObject hintObject;

    private Difficulty setDifficulty;

    private void Start()
    {

        foreach (var difficulty in difficulties)
        {
            if (difficulty.difficultyLevel == difficultyLevel)
            {
                setDifficulty = difficulty;
                AmountOfDefintions = setDifficulty.amountOfDefinitions;
                MaxAmountOfHints = setDifficulty.maxAmountOfHints;
            }
        }
        GenerateCards();
        PlaceCards();
    }

    // Update is called once per frame
    public void PlaceCards()
    {


        GameObject CardsParent = Instantiate(setDifficulty.cardPositionPrefab, transform); 

        for (int i = 0; i < CardsParent.transform.childCount; i++)
        {
            CardDisplay display = CardsParent.transform.GetChild(i).GetComponent<CardDisplay>();

            display.card = CurrentCards[Random.Range(0, CurrentCards.Count)];
            display.hintObject = hintObject;
            CurrentCards.Remove(display.card);
        }
    }

    public void GenerateCards()
    {
        for (int i = 0; i < AmountOfDefintions; i++) //GetRandomDefinitions
        {
            int definitionIndex = Random.Range(0, definitions.Count);
            currentDefinitions.Add(definitions[definitionIndex]);
            definitions.Remove(definitions[definitionIndex]);
        }

        foreach(Defintion definition in currentDefinitions)
        {
            string[] hints = new string[MaxAmountOfHints];

            int i = 0;
            while(i < MaxAmountOfHints)
            {
                if(definition.Hints.Count == 0) { Debug.LogError("No hints found for definition: " + definition.Definition); break; }
                string hint = definition.Hints[Random.Range(0, definition.Hints.Count)];
                if (hints.Contains(hint))
                {
                    continue;
                }
                else
                {
                    hints[i] = hint;
                    i++;
                }
            }

            for (int j = 0; j < hints.Length; j++)
            {
                Card card = new Card(hints[j], definition.Definition);
                CurrentCards.Add(card);
            }
        }
    }
}
