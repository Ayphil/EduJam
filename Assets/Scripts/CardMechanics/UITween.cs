using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //This script is used to scale the GameObject when the mouse pointer enters and exits the GameObject
    //It uses the PrimeTween library to animate the scaling
    //The scale factor can be adjusted in the inspector
    //Scale factor for the GameObject when hovered over

    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float initialScale = 1f;

    private void Start()
    {
        initialScale = transform.localScale.x;
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Tween.Scale(transform, initialScale * scaleFactor, 0.2f);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Tween.Scale(transform, initialScale, 0.2f);
    }

}
