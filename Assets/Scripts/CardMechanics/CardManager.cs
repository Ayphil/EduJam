using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("To set yourself")]

    [SerializeField] List<Defintion> definitions = new List<Defintion>();

    [SerializeField] List<Difficulty> difficulties = new List<Difficulty>();

    [SerializeField] private GameObject hintObject;

    [SerializeField] private Transform cardsParent;

    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private HUD hudScript;

    [Header("Internal Logic/Debugging")]

    [SerializeField] private Difficulty.DifficultyLevel difficultyLevel;

    [SerializeField] private int AmountOfDefintions = 0;

    [SerializeField] private int MaxAmountOfHints = 0;

    [SerializeField] private List<Defintion> currentDefinitions = new List<Defintion>();

    [SerializeField] private List<CardDisplay> CardDisplayObjects = new List<CardDisplay>();

    [SerializeField] private int numberOfFlippedCards = 0;

    private Difficulty setDifficulty;

    private List<Card> CurrentCards = new List<Card>();

    private string currentDefinition = "";

    private void OnEnable()
    {
        CardDisplay.flipCard += onCardFlipped;
        inputField.onEndEdit.AddListener(WriteDefinition);
    }

    private void OnDisable()
    {
        CardDisplay.flipCard -= onCardFlipped;
        inputField.onEndEdit.RemoveListener(WriteDefinition);
    }
    private void Start()
    {
        if (difficulties.Count == 0 || hintObject == null || inputField == null)
        {
            Debug.LogError("Critical components not assigned in inspector!");
            return;
        }

        foreach (var difficulty in difficulties)
        {
            if (difficulty.difficultyLevel == difficultyLevel)
            {
                setDifficulty = difficulty;
                AmountOfDefintions = setDifficulty.amountOfDefinitions;
                MaxAmountOfHints = setDifficulty.maxAmountOfHints;
            }
        }
        if (setDifficulty == null)
        {
            Debug.LogError($"Difficulty level '{difficultyLevel}' not found in the difficulties list! Aborting CardManager setup.");
            this.enabled = false; // Disable the component to prevent further errors
            return; // Stop execution of Start()
        }

        GenerateCards();
        PlaceCards();


    }

    private void onCardFlipped(Card card)
    {
        Debug.Log(card.definition);
        if (currentDefinition == card.definition)
        {
            numberOfFlippedCards++;
        }
        else
        {
            currentDefinition = card.definition;

            foreach (CardDisplay cardDisplay in CardDisplayObjects)
            {
                if (!cardDisplay.isFlipped) continue;
                cardDisplay.TurnCard();
            }
            numberOfFlippedCards = 1;
        }
    }



    // Update is called once per frame
    public void PlaceCards()
    {

        GameObject CardsParent = Instantiate(setDifficulty.cardPositionPrefab, cardsParent); 

        for (int i = 0; i < CardsParent.transform.childCount; i++)
        {
            CardDisplay display = CardsParent.transform.GetChild(i).GetComponent<CardDisplay>();

            if (CurrentCards.Count > 0)
            {
                display.card = CurrentCards[Random.Range(0, CurrentCards.Count)];
                display.hintObject = hintObject;
                CardDisplayObjects.Add(display);
                CurrentCards.Remove(display.card);
            }
            else
            {
                Debug.LogError("Ran out of cards to assign!");
            }
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
            int b = 0;
            while(i < MaxAmountOfHints)
            {
                b++;
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

                if (b > 1000)
                {
                    Debug.LogError("Too many iterations while generating hints for definition: " + definition.Definition);
                    break;
                }
               }

            for (int j = 0; j < hints.Length; j++)
            {
                Card card = new Card(hints[j], definition.Definition);
                CurrentCards.Add(card);
            }
        }
    }

    public void WriteDefinition(string input)
    {
        Debug.Log(input);
        List<GameObject> cardsToDestroy = new List<GameObject>();
        foreach (CardDisplay card in CardDisplayObjects)
        {
            if(card.card.definition == input)
            {
                cardsToDestroy.Add(card.gameObject);
            }
        }

        for(int i = cardsToDestroy.Count-1; i >= 0; i--)
        {
            hintObject.SetActive(false);
            inputField.text = "";
            CardDisplayObjects.Remove(cardsToDestroy[i].GetComponent<CardDisplay>());
            Destroy(cardsToDestroy[i]);
            hudScript.GetCheckmarks(difficultyLevel);
        }
    }


}
