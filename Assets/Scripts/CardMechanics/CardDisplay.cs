using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public Card card;

    [SerializeField] public GameObject hintObject;
    public void ShowHint()
    {
        hintObject.SetActive(true);
        hintObject.GetComponentInChildren<TMP_Text>().text = card.hint;
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
