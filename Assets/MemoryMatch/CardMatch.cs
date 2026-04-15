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
    bool isUnlocked;
    float holdTime = 1f;
    
   


    public void OnEnable()
    {
        isSelected = true;
        EventManager.startGame += ResetCards;
        EventManager.failedMatch += ResetCards;
        EventManager.locked += LockCards;
        EventManager.unlock += UnlockCards;
        EventManager.displayCards += ShowCards;
    }

    private void OnDisable()
    {
        EventManager.startGame -= ResetCards;
        EventManager.failedMatch -= ResetCards;
        EventManager.locked -= LockCards;
       

    }
    private void OnMouseDown()
    {

        Debug.Log(CardType);
        if (!isSelected && !isLocked)
            StartCoroutine(TurnCardOver());
    }

    public void ShowCards()
    {
        StartCoroutine(DisplayCards());
    }
    IEnumerator DisplayCards()
    {
        float turnTime = 0;
        string cardTypeString = CardType.ToString();
        Debug.Log("Card type" + cardTypeString);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);
        
        while (turnTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;

            yield return null;
        }
        EventManager.displayCards -= ShowCards;
    }

    IEnumerator TurnCardOver()
    {
        float turnTime = 0;
        string cardTypeString = CardType.ToString();
        Debug.Log("Card type" + cardTypeString);
        EventManager.ChosenCards.Invoke(cardTypeString);
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


        yield break;
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
        yield return new WaitForSeconds(holdTime);

        float turnTime = 0;
        
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 180, 0);
        
        EventManager.unlock.Invoke();
        
        while (turnTime < turnDuration && isSelected)
        { 
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);
            
            turnTime += Time.deltaTime;
            yield return null;
        }
        isUnlocked = false;
        EventManager.SelectedCard -= MatchedCards;
        isSelected = false;
        yield break;
    }
    void LockCards()
    {
        isLocked = true;

    }
    void UnlockCards()
    { 
        isLocked = false;
        isUnlocked = true;
    }

    void MatchedCards()
    {
        EventManager.failedMatch -= ResetCards;
        EventManager.unlock -= UnlockCards;
        
    }
}
