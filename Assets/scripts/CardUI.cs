using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{

    [SerializeField] private GameObject parentObject;
    private List<GameObject> cardGOs;

    private void Awake()
    {
        cardGOs = new List<GameObject>();
    }

    public void DisplayCard(Card card)
    {
        Card displayCard = Instantiate(card.gameObject, parentObject.transform).GetComponent<Card>();
        cardGOs.Add(displayCard.gameObject);
        
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
}
