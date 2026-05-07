using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HL_DealCards : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private Transform GameUI;
   public List<GameObject> orderOfCards = new List<GameObject>();
  
     private void OnEnable()
    {
        EventManager.CardDealer += DealCards;
    }
    private void OnDisable()
    {
        EventManager.CardDealer -= DealCards;
    }
    public void DealCards(GameObject[] cardList)
    {
        StartCoroutine(DealingCards(cardList));
    }

    IEnumerator DealingCards(GameObject[] cards)
    {
        
        for(int i = 0; i < cards.Length; i++)
        {
            GameObject card = Instantiate(cards[i], spawnPosition.transform.position, Quaternion.Euler(0,180,0));
            card.transform.SetParent(GameUI);
            orderOfCards.Add(card);
            if (i > 1)
            {
                card.SetActive(false);
            }
        }

        EventManager.locked.Invoke();
        EventManager.drawCard.Invoke("default");


        yield return null;
    }
}

