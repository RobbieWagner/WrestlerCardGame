using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] public List<Card> deckCards;
    private List<Card> discardPile;
    public CardUI cardUI;

    private void Awake() 
    {
        discardPile = new List<Card>();
    }

    public void DrawCards(int cardAmount)
    {
        if(cardAmount > deckCards.Count) RefreshDeck();
        for(int i = 0; i < cardAmount; i++)
        {
            Card cardToDisplay = deckCards[0];
            if(cardUI != null) cardUI.DisplayCard(cardToDisplay);
            discardPile.Add(cardToDisplay);
            deckCards.Remove(cardToDisplay);
        }
    }

    public void RefreshDeck()
    {
        foreach(Card card in discardPile)
        {
            deckCards.Add(card);
        }

        ShuffleCardDeck(deckCards);
    }

    private List<Card> ShuffleCardDeck(List<Card> deck)
    {
        int i = deck.Count;
        while(i > 1)
        {
            i--;
            int random = UnityEngine.Random.Range(0, i + 1);
            Card value = deck[random];
            deck[random] = deck[i];
            deck[i] = value;
        }

        return deck;
    }
}
