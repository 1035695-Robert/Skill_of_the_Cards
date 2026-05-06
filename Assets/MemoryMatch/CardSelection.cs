using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;

public class CardSelection : MonoBehaviour
{
    public int cardCount;
    public List<string> typeList = new List<string>();

    public int matchedCount;
    public int maxPairAmount = 9;
    public int maxTurns = 3;
    public int turnsLeft;

    private void Start()
    {
        turnsLeft = maxTurns;
    }

    private void OnEnable()
    {
        EventManager.ChosenCards += CardCountCheck;
    }
    private void OnDisable()
    {
        EventManager.ChosenCards -= CardCountCheck;
    }

    public void CardCountCheck(string cardType)
    {
        Debug.Log(cardType);
        typeList.Add(cardType);

        switch (typeList.Count)
        {
            case 0:
                Debug.Log("default");
                break;
            case 1:
                Debug.Log("1 card selected");
                break;
            case 2:
                Debug.Log("2 Cards Selected");
                Debug.Log(string.Join(",", typeList));
                EventManager.locked.Invoke();
                StartCoroutine(MatchCheck());
                break;
        }
    }
    IEnumerator MatchCheck()
    {
        yield return new WaitForSeconds(1f);
        string[] typeListArray = typeList.ToArray();

        if (typeListArray[0] == typeListArray[1])
        {
            Debug.Log("Match"); 
            matchedCount++;
            EventManager.SelectedCard.Invoke();

            EventManager.starCheck.Invoke(matchedCount, maxPairAmount);

            if (matchedCount == maxPairAmount)
            {
                EventManager.winCondtion.Invoke();
                Debug.Log("Congrats");
                yield break;
            }
            EventManager.unlock.Invoke();
        }
        else
        {
            turnsLeft--;
           
            EventManager.failed.Invoke(turnsLeft);
            yield return new WaitForSeconds(1f);
            EventManager.slideAudio.Invoke();
        }
        if (turnsLeft == 0)
        {
            EventManager.endCondtion.Invoke("Matched", maxPairAmount);
            yield break;
        }
     
        typeList.Clear();
      
    }
}
