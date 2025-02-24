using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Library", menuName = "Card Library")]
public class CardLibrary : ScriptableObject
{
    public List<Card> allCards; // List of all possible cards
}