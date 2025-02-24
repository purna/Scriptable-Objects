using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Deck playerDeck;
    public Deck computerDeck;
    public CardLibrary cardLibrary; // Reference to the card library


    public GameObject playButtonPanel; // Panel with the Play Button
    public GameObject cardDisplayPanel; // Panel with the Card Displays

    public CardDisplay playerCardDisplay; // Reference to the player's CardDisplay
    public CardDisplay computerCardDisplay; // Reference to the PC's CardDisplay

    private Card playerCard;
    private Card computerCard;

    public TMP_Text _result;

    void Start()
    {
         // Initialize the game
        GameStart();
        
        // Hide the card display panel and show the play button panel at the start
        playButtonPanel.SetActive(true);
        cardDisplayPanel.SetActive(false);
    }

        // Call this method to initialize the game
    void GameStart()
    {
        // Clear existing cards in the decks
        playerDeck.cards.Clear();
        computerDeck.cards.Clear();

        // Add 10 random cards to the player's deck
        for (int i = 0; i < 10; i++)
        {
            Card randomCard = cardLibrary.allCards[Random.Range(0, cardLibrary.allCards.Count)];
            playerDeck.cards.Add(randomCard);
        }

        // Add 10 random cards to the computer's deck
        for (int i = 0; i < 10; i++)
        {
            Card randomCard = cardLibrary.allCards[Random.Range(0, cardLibrary.allCards.Count)];
            computerDeck.cards.Add(randomCard);
        }

        Debug.Log("Decks initialized with 10 random cards each.");
    }


    // Call this method when the Play Button is clicked
    public void OnPlayButtonClicked()
    {
        // Hide the play button panel and show the card display panel
        playButtonPanel.SetActive(false);
        cardDisplayPanel.SetActive(true);

        // Shuffle both decks
        playerDeck.Shuffle();
        computerDeck.Shuffle();

        // Play a round
        PlayRound();
    }

    void PlayRound()
    {
        // Draw cards for player and computer
        playerCard = playerDeck.DrawCard();
        computerCard = computerDeck.DrawCard();

        if (playerCard == null || computerCard == null)
        {
            Debug.Log("Game Over! One of the decks is empty.");
            return;
        }

        // Update the card displays
        playerCardDisplay.card = playerCard;
        playerCardDisplay.UpdateCardDisplay();

        computerCardDisplay.card = computerCard;
        computerCardDisplay.UpdateCardDisplay();

        // Compare card values
        Debug.Log("Player drew: " + playerCard.name + " (Value: " + playerCard.attack + ")");
        Debug.Log("Computer drew: " + computerCard.name + " (Value: " + computerCard.attack + ")");

        if (playerCard.attack > computerCard.attack)
        {
            Debug.Log("Player wins the round!");
            _result.text = "Player wins the round!";
        }
        else if (playerCard.attack < computerCard.attack)
        {
            Debug.Log("Computer wins the round!");
            _result.text = "Computer wins the round!";
        }
        else
        {
            Debug.Log("It's a tie!");
            _result.text = "It's a tie!";
        }
    }
}