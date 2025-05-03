using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public bool isFlipped = false;

    [SerializeField] public Card card;

    [SerializeField] public GameObject hintObject;

    public delegate void FlipCard(Card card);

    public static event FlipCard flipCard;
    public void ShowHint()
    {
        hintObject.SetActive(true);
        hintObject.GetComponentInChildren<TMP_Text>().text = card.hint;
        flipCard (card);
        TurnCard();
    }

    public void TurnCard()
    {
        isFlipped = !isFlipped;

        if (isFlipped) { GetComponent<Image>().color = Color.red; }
        else { GetComponent<Image>().color = Color.white; }
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
