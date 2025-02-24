using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
public class Deck : ScriptableObject
{
    public List<Card> cards; // List of cards in the deck

    // Shuffle the deck
    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    // Draw a card from the deck
    public Card DrawCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            return null;
        }

        Card drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }
}