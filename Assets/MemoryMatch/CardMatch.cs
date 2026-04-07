using JetBrains.Annotations;
using System.Collections;
using System.Data.SqlTypes;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum CardTypes
{
    Null,
    Square,
    Triangle,
    Circle,
    Star,
    Heart,
    Diamond,
    Pentagon,
    Cross,
    Arrow
}


public class CardMatch : MonoBehaviour
{
    public CardTypes CardType;
    public float turnDuration = 2.0f;
    public bool isSelected;
    public bool isLocked;



    public void OnEnable()
    {
        isSelected = true;
        EventManager.startGame += ResetCards ;
        EventManager.failedMatch += ResetCards;
        EventManager.locked += LockedCards;
    }
    private void OnMouseDown()
    {

        Debug.Log(CardType);
        if (!isSelected && !isLocked)
            StartCoroutine(TurnCardOver());
    }

    IEnumerator TurnCardOver()
    {
        float turnTime = 0;
        string cardTypeString = CardType.ToString();
        Debug.Log("Card type" + cardTypeString);      
        EventManager.CardSelected.Invoke(cardTypeString);
        EventManager.SelectedCard += MatchedCards;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);
        isSelected = true;
        while (turnTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;
            yield return null;
        }
       

        yield return null;
    }
    public void ResetCards()
    {
        StartCoroutine(ResetAllCards());
    }
    public void ResetCards(int maxTurns)
    {
        StartCoroutine(ResetAllCards());
    }

    IEnumerator ResetAllCards()
    {
        float turnTime = 0;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 180, 0);

        while (turnTime < turnDuration && isSelected)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;
            yield return null;
        }
        EventManager.SelectedCard -= MatchedCards;

        isSelected = false;
        yield return null;
    }
    void LockedCards()
    {
        isLocked = !isLocked;
    }

    void MatchedCards()
    {
        EventManager.failedMatch -= ResetCards;
        //card will no longer Flip since already paired
    }
}
