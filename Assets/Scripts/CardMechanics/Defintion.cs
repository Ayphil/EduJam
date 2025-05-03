using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Definiton", menuName = "ScriptableObjects/Definition", order = 1)]
public class Defintion : ScriptableObject
{
    public string Definition;
    [TextArea(3, 10)]
    public List<string> LinkedCards = new List<string>();
}
