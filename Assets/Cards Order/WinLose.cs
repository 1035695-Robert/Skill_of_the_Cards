using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    
    public GameObject WinConditionUI;
    public GameObject LoseConditionUI;
   

     public TimeScoreText timeScore;
    public Timer timer;
    [SerializeField] TextMeshProUGUI finalTimeText;
    public void Win()
    {   
        
        WinConditionUI.SetActive(true);
        timer.gameInPlay = false;

        finalTimeText.text = "Time\n" + timer.currentTime;
        timeScore.BestTimeCheck(timer.Second);
        // set score

        // compare best time and current time
        // update scores

    }
public void Lose()
    {
        LoseConditionUI.SetActive(true);
        timer.gameInPlay = false;
        
        

    }
}

