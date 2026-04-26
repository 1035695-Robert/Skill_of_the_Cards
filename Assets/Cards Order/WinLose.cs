using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    
    public GameObject WinConditionUI;
    public GameObject LoseConditionUI;
    public GameObject GameElements;

     public TimeScoreText timeScore;
    public Timer timer;
    [SerializeField] TextMeshProUGUI finalTimeText;

    public void OnEnable()
    {
        EventManager.winCondition += Win;
        EventManager.loseCondition += Lose;
    }
    public void OnDisable()
    {
        EventManager.winCondition -= Win;
        EventManager.loseCondition -= Lose;
    }
    public void Win()
    {   
        WinConditionUI.SetActive(true);
        timer.gameInPlay = false;
        GameElements.SetActive(false);
        finalTimeText.text = "Time\n" + timer.currentTime;
        timeScore.BestTimeCheck(timer.Second);
    }
public void Lose()
    {
        LoseConditionUI.SetActive(true);
        timer.gameInPlay = false;
        GameElements.SetActive(false);




    }
}

