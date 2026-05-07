using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawCard : MonoBehaviour
{

    [SerializeField] GameObject[] slot;
    public HL_DealCards dealCards;
    public int cardId;

    public int maxTurns = 3;
    public int turnsLeft;
    public int correctCount;

    private void Start()
    {
        dealCards = GetComponent<HL_DealCards>();
        cardId = 0;
        turnsLeft = maxTurns;
    }
    private void OnEnable()
    {
        EventManager.drawCard += DrawingCard;
    }
    private void OnDisable()
    {
        EventManager.drawCard -= DrawingCard;
    }
    void DrawingCard(string selection)
    {

        

        dealCards.orderOfCards[cardId].transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.5f);
        dealCards.orderOfCards[cardId].transform.DOMove(slot[0].transform.position, 0.1f);
        //playSound FX
        EventManager.dropAudio.Invoke();
        if (cardId > 0)
        {
            dealCards.orderOfCards[cardId - 1].transform.DOMove(slot[1].transform.position, 0.1f);
            EventManager.slideAudio.Invoke();
            if (cardId >= 2)
                dealCards.orderOfCards[cardId - 2].SetActive(false);
            CheckSelection(selection, cardId);
        }

        if (cardId <= 10)
        {
            dealCards.orderOfCards[cardId + 2].SetActive(true);
        }
        cardId++;
        if (cardId >= dealCards.orderOfCards.Count) //add failattempts
        {
            GameOver();
            return;
        }

    }
    void CheckSelection(string selection, int i)
    {
        CardValue C1 = dealCards.orderOfCards[i].GetComponent<CardValue>();
        CardValue C2 = dealCards.orderOfCards[i - 1].GetComponent<CardValue>();
        switch (selection)
        {
            case "default":
                break;
            case "Higher":
                if (C1.cardNumber > C2.cardNumber)
                {
                    Correct();
                    Debug.Log("card is Higher");
                }
                else
                    Failed();
                break;
            case "Lower":
                if (C1.cardNumber < C2.cardNumber)
                {
                    Correct();
                    Debug.Log("card is lower");
                }
                else
                    Failed();
                break;

        }
    }

    void Correct()
    {
        correctCount ++ ;
        EventManager.starCheck.Invoke(correctCount, dealCards.orderOfCards.Count - 1);
    }
    void Failed()
    {
        turnsLeft--;
        Debug.Log("failed");
        EventManager.failed.Invoke(turnsLeft);
        if (turnsLeft == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        EventManager.endCondtion.Invoke("Correct", dealCards.orderOfCards.Count - 1);
    }
}

