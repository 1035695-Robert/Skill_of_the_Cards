using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class DealCardsMatch : MonoBehaviour
{

    public CardPlacementSlot[] cardSlots;


    public float waitTime;

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
            //card.transform.Rotate(0, 180, 0);
        }

        StartCoroutine(FlipDelay());

    }
    IEnumerator FlipDelay()
    {
        yield return new WaitForSeconds(waitTime);
        EventManager.startGame.Invoke();
    }

}

