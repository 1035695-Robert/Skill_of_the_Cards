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

    [SerializeField] public AudioClip[] flipCardClip;
    private AudioSource audioSource;


    public void OnEnable()
    {
        isSelected = true;
        EventManager.startGame += ResetCards;
        EventManager.failedMatch += ResetCards;
        EventManager.locked += LockCards;
        EventManager.unlock += UnlockCards;
        EventManager.displayCards += ShowCards;

        if (audioSource == null)
        {
            GameObject audioSourceObject = GameObject.Find("Audio Source");
            audioSource = audioSourceObject.GetComponent<AudioSource>();

        }
    }

    private void OnDisable()
    {
        EventManager.startGame -= ResetCards;
        EventManager.failedMatch -= ResetCards;
        EventManager.locked -= LockCards;
        EventManager.displayCards -= ShowCards;


    }
    private void OnMouseDown()
    {
        if (!isSelected && !isLocked)
            StartCoroutine(TurnCardOver());
    }

    public void ShowCards(int degrees)
    {
        StartCoroutine(DisplayCards(degrees));
    }
    IEnumerator DisplayCards(int degrees)
    {
        float turnTime = 0;
        string cardTypeString = CardType.ToString();
        Debug.Log("Card type" + cardTypeString);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, degrees, 0);

        
        while (turnTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;

            yield return null;
        }
        if (degrees == 180)
        {
            isSelected = false;
        }
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
        EventManager.slideAudio.Invoke();
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
