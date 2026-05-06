using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public GameObject endConditionUI;
    public GameObject cardSlotUI;
    public GameObject[] star;

    
    
    public int totalCount = 0;
    public int starCount;
    public TextMeshProUGUI displayText;
    public GameObject[] failed;
    
    public int MaxTurns = 3;
    private void OnEnable()
    {
        EventManager.failed += Lives;
        EventManager.starCheck += StarLevels;
        EventManager.endCondtion += EndCondtition;
       
        if (endConditionUI == true)
        {
            endConditionUI.SetActive(false);
        }

    }
    private void OnDisable()
    {
        EventManager.failed -= Lives;
        EventManager.starCheck -= StarLevels;
        EventManager.endCondtion -= EndCondtition;
    }

    public void EndCondtition(string gameInfo, int maxCount)
    {
       // Lives(MaxTurns);
        endConditionUI.SetActive(true);
       
        displayText.text = gameInfo + ": " + totalCount.ToString() + "/" + maxCount.ToString();
        cardSlotUI.SetActive(false);
    }

    public void Lives(int maxTurns)
    {
        switch (maxTurns)
        {
            case 0:
                failed[0].SetActive(true);
                failed[1].SetActive(true);
                failed[2].SetActive(true);
                break;
            case 1:
                failed[0].SetActive(true);
                failed[1].SetActive(true);
                failed[2].SetActive(false);
                Debug.Log("lives left:" + MaxTurns);
                
                break;
            case 2:
                failed[0].SetActive(true);
                failed[1].SetActive(false);
                failed[2].SetActive(false);
                Debug.Log("lives left:" + MaxTurns);
                break;
            case 3:
                failed[0].SetActive(false);
                failed[1].SetActive(false);
                failed[2].SetActive(false);
                Debug.Log("lives left:" + MaxTurns); //Default
                break;
        }
    }


    public void StarLevels(int count, int maxAmount)
    {
        totalCount = count;
        starCount = count / (maxAmount/3);
        Debug.Log(starCount);
        switch (starCount)
        {
            case 0: // less than 3
                star[0].SetActive(false);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;

            case 1:
                star[0].SetActive(true);
                star[1].SetActive(false);
                star[2].SetActive(false);
                break;

            case 2:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(false);
                break;

            case 3:
                star[0].SetActive(true);
                star[1].SetActive(true);
                star[2].SetActive(true);
                break;

            default:
                break;
        }

    }
}
