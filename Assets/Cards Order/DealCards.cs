using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class DealCards : MonoBehaviour
{
    public CardManager cardManager;

    [SerializeField] public List<GameObject> myHand = new List<GameObject>();
    [SerializeField] private int myHandSize = 5;
    void Start()
    {
        cardManager = GetComponent<CardManager>();
    }

    public void DealCardToPlayer()
    {
        for (int i = 0; i < myHandSize; i++)
        {
            myHand.Add(cardManager.playingCards[i]);
            GameObject cardInHand = Instantiate(cardManager.playingCards[i], transform.position, Quaternion.identity);
          cardInHand.name = cardInHand.name.TrimEnd("(Clone)");
        }
    }
    //{// have each card 

    //    for (int i = 0; i < myHand.Length; i++)
    //    {
    //        Debug.Log("dealCards");
    //        CardManager cardManager = new CardManager();
    //        cardManager.playingCards[i].SetActive(true);
    //    }

}
