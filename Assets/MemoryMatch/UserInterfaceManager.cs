using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public GameObject endConditionUI;
    public GameObject cardSlotUI;
    public GameObject[] star;
    
    
    public int matchedCount;
    public TextMeshProUGUI Matched;

    public int MaxTurns = 3;
    private void OnEnable()
    {
        EventManager.failedMatch += Lives;
        EventManager.starCheck += StarLevels;
        EventManager.winCondition += EndCondtition;
        if (endConditionUI == true)
        {
            endConditionUI.SetActive(false);
        }
    }
    private void OnDisable()
    {
        EventManager.failedMatch -= Lives;
        EventManager.starCheck -= StarLevels;
        EventManager.winCondition -= EndCondtition;
    }

    public void EndCondtition()
    {
        endConditionUI.SetActive(true);
        Matched.text = "Matched: " + matchedCount.ToString();
        cardSlotUI.SetActive(false);
    }

    public void Lives(int maxTurns)
    {
        switch (maxTurns)
        {
            case 0:
                //EndCondtition();
                break;
            case 1:
                Debug.Log("lives left:" + MaxTurns);
                break;
            case 2:
                Debug.Log("lives left:" + MaxTurns);
                break;
            case 3:
                Debug.Log("lives left:" + MaxTurns); //Default
                break;



        }
    }


    public void StarLevels(int count)
    {
        matchedCount = count;

        switch (matchedCount)
        {
            case < 3: // less than 3
                star[0].SetActive(false);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;

            case >= 3 and < 6:
                star[0].SetActive(true);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;

            case >= 6 and < 9:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(false);
                break;

            case 9:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(true);
                break;

            default:
                break;
        }

    }
}
