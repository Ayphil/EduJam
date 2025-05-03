using Animancer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public bool isFlipped = false;

    [SerializeField] public Card card;

    [SerializeField] public GameObject hintObject;

    [SerializeField] public AnimationClip flipAnimation2;
    [SerializeField] public AnimationClip flipAnimation1;

    [SerializeField] public AnimancerComponent brain;
     
    public delegate void FlipCard(Card card);

    public static event FlipCard flipCard;
    public void ShowHint()
    {
        hintObject.SetActive(true);
        hintObject.GetComponentInChildren<TMP_Text>().text = card.hint;
        flipCard (card);
        brain.Play(flipAnimation1);
        hintObject.SetActive(true);
        isFlipped = true;
    }

    public void TurnCard()
    {
        isFlipped = !isFlipped;

        if(!isFlipped)
        {
            brain.Play(flipAnimation2);
        }
    }
}

[System.Serializable]
public class Card 
{
    public string hint;
    public string definition;

    public Card(string hint, string definition)
    {
        this.hint = hint;
        this.definition = definition;
    }
}
