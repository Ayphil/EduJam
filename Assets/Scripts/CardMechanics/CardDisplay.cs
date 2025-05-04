using Animancer;
using MoreMountains.Feedbacks;
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

    [SerializeField] public AudioSource flipSound1;
     
    public delegate void FlipCard(Card card);

    public static event FlipCard flipCard;
    private void Start()
    {
        GetComponent<MMF_Player>().GetFeedbackOfType<MMF_AudioSource>().TargetAudioSource = flipSound1;
    }
    public void ShowHint()
    {
        hintObject.SetActive(true);
        hintObject.GetComponentInChildren<TMP_Text>().text = card.hint;
        flipCard (card);
        brain.Play(flipAnimation1);
        hintObject.SetActive(true);
        isFlipped = true;
        GetComponent<MMF_Player>().PlayFeedbacks();

    }

    public void TurnCard()
    {
        GetComponent<MMF_Player>().PlayFeedbacks();
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
