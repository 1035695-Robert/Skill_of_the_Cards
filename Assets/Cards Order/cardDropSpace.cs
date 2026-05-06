using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cardDropSpace : MonoBehaviour, ICardDropArea
{
    public Transform cardDropZone;
    public CardPlacementList placementList = new CardPlacementList();
    public CardPlacementSlot[] cardSlots;

  

    public void OnCardDrop(CardMovement card, string name, int number)
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (cardSlots[i].isFull == false)
            {
                EventManager.dropAudio.Invoke();
                card.transform.SetParent(cardSlots[i].transform);
                card.transform.position = cardSlots[i].transform.position;
                card.transform.rotation = cardSlots[i].transform.rotation;
                cardSlots[i].isFull = true;
                placementList.cardNumber.Add(number);
                if (i == cardSlots.Length - 1)
                {
                    Debug.Log("there");
                    StartCoroutine(CheckCardOrder());
                    return;
                }
                return;
            }
        }
    }
    public IEnumerator CheckCardOrder()
    {
        
        for (int i = 0; i < placementList.cardNumber.Count - 1; i++)
        {
            if (placementList.cardNumber[i] < placementList.cardNumber[i + 1])
            {
                Debug.Log("correct" + (i + 1) + "/" + (placementList.cardNumber.Count));
                if (i + 1 == placementList.cardNumber.Count - 1)
                {
                    
                    Debug.Log("<color=yellow> winner </color>" + (i + 2) + "/" + placementList.cardNumber.Count);
                    EventManager.winCondtion();
                }

                yield return null;
            }
            else
            {
                //lose condition
                Debug.Log("<color=red> incorrect </color>");
                EventManager.loseCondition.Invoke();
                yield break;
            }
        }

    }

}

