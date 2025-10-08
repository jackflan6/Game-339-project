using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardPlacer : MonoBehaviour
{
    public List<Card> allCards;
    public GameObject cardPrefab;
    public List<Card> cardsInDeck;
    public List<Card> cardsInHand;
    public List<Card> cardsInDiscard;
    
    public float spacing = 2f;
    private int cardsPlaced = 0;
    public Vector3 startPosition = Vector3.zero;

    private List<Card> cardsStillInDeck;

    public int cardsDrawnPerTurn = 0;
    public int startingHandSize = 5;
    public int maximumHandSize = 10;

    private void Awake()
    {
        cardsStillInDeck = new List<Card>(allCards);
    }

    public Card ChooseRandomCard()
    {
        if (cardsStillInDeck.Count == 0)
        {
            if (cardsInDiscard.Count == 0)
            {
                Debug.LogWarning("No cards left in deck or discard pile");
                return null;
            }

            cardsStillInDeck = new List<Card>(cardsInDiscard);
            cardsInDiscard.Clear();
        }

        int randomIndex = Random.Range(0, cardsStillInDeck.Count);
        Card chosenCard = cardsStillInDeck[randomIndex];
        return chosenCard;
    }

    private Vector3 CalculateCardPosition()
    {
        float x = startPosition.x + cardsPlaced * spacing;
        float y = startPosition.y;
        float z = startPosition.z;

        return new Vector3(x, y, z);
    }

    public void PlaceCard()
    {
        Card chosenCard = ChooseRandomCard();
        
        Vector3 position = CalculateCardPosition();
        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);

        CardDisplay display = newCard.GetComponent<CardDisplay>();
        display.cardData = chosenCard;

        cardsDrawnPerTurn++;
        cardsInHand.Add(chosenCard);
        cardsStillInDeck.Remove(chosenCard);
    }

    public void DrawHand()
    {
        while(cardsPlaced <= 5)
        {
            PlaceCard();
        }
    }

    public void DrawForTurn()
    {
        while (cardsDrawnPerTurn <= 3)
        {
            PlaceCard();
        }
    }
}
