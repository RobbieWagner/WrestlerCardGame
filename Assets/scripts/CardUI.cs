using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{

    [SerializeField] private GameObject parentObject;
    private List<GameObject> cardGOs;

    [SerializeField] private float cardMinXPosition;
    [SerializeField] private float cardMaxXPosition;
    [SerializeField] private float cardYPosition;

    public static CardUI Instance { get; private set; }

    private void Awake()
    {
        cardGOs = new List<GameObject>();

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void DisplayCard(Card card)
    {
        Card displayCard = Instantiate(card.gameObject, parentObject.transform).GetComponent<Card>();
        cardGOs.Add(displayCard.gameObject);
        UpdateHand();
        
        DisplayCardInformation(displayCard);
    }

    private void DisplayCardInformation(Card card)
    {
        card.titleText.text = card.cardTitle; 

        card.powerText.text = card.power.ToString();
        card.accuracyText.text = card.accuracy.ToString();
        card.entertainmentText.text = card.entertainment.ToString();
        card.staminaCostText.text = card.cost.ToString();
    }

    public void RemoveCards()
    {
        while(cardGOs.Count > 0)
        {
            Destroy(cardGOs[0]);
            cardGOs.RemoveAt(0);
        }
    }

    private void UpdateHand()
    {
        float spacing = (cardMaxXPosition - cardMinXPosition)/(cardGOs.Count-1);

        for(int i = 0; i < cardGOs.Count; i++)
        {
            RectTransform rectTransform = cardGOs[i].GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector2(cardMinXPosition + spacing * i, cardYPosition);
        }
    }
}
