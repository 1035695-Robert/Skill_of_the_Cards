using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;


public class DealCardsMatch : MonoBehaviour
{

    public CardPlacementSlot[] cardSlots;
    public Transform spawnPosition;

    

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
        StartCoroutine(DealingCards(cardList));
    }
   
    IEnumerator DealingCards(GameObject[] cardList)
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < cardSlots.Length; i++)
        {
            GameObject card = Instantiate(cardList[i], spawnPosition);
            Debug.Log(card.name);
            card.transform.SetParent(cardSlots[i].transform);
            card.transform.DOMove(cardSlots[i].transform.position, 0.1f);
            
            

            yield return new WaitForSeconds(0.1f);

            //card.transform.Rotate(0, 180, 0);
        }
        EventManager.displayCards.Invoke();
        yield return new WaitForSeconds(2f);
        EventManager.startGame.Invoke();
    }

}

