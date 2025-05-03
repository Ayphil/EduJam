using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hint", menuName = "ScriptableObjects/Hint", order = 1)]
public class Hint : ScriptableObject
{
    [TextArea(3, 10)]
    public string hint;
    public List<Hint> LinkedCards = new List<Hint>();
}
