using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;


public class DealCardsMatch : MonoBehaviour
{

    public CardPlacementSlot[] cardSlots;
    public List<GameObject> cards;

    public void OnEnable()
    {
        EventManager.CardDealer += DealCards;
    }
    public void OnDisable()
    {
        EventManager.CardDealer -= DealCards;
    }

    public void DealCards(GameObject[] cardList)
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
                GameObject card = Instantiate(cardList[i]);
                Debug.Log(card.name);
                card.transform.SetParent(cardSlots[i].transform);
                card.transform.position = cardSlots[i].transform.position;
      
        }
        //start game
    }
    
}

