using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;


public class DealCardsMatch : MonoBehaviour
{

    public CardPlacementSlot[] cardSlots;
    public Transform spawnPosition;

    public float timeDuration = 3;
    public GameObject timerObject;
    public TextMeshProUGUI countDown;
    private AudioSource audioSource;
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

            //playSound FX
            EventManager.dropAudio.Invoke();

            yield return new WaitForSeconds(0.1f);

            //card.transform.Rotate(0, 180, 0);
        }
        EventManager.displayCards.Invoke(0);
        EventManager.slideAudio.Invoke();
        timerObject.SetActive(true);
        StartCoroutine(TimeToMemorise());
        //yield return new WaitForSeconds(waitTime);

    }
    IEnumerator TimeToMemorise()
    {
        float waitTime = timeDuration;
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(waitTime);
            if (seconds <= 0)
            { seconds = 0; }

            countDown.text = seconds.ToString() + " Seconds Left";
            yield return null;
        }
        timerObject.SetActive(false);
        yield return null;
        EventManager.displayCards.Invoke(180);
        EventManager.slideAudio.Invoke();
    }
}

