using TMPro;
using UnityEngine;
using System;
using System.Collections;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentTimeText;
  
   

    float countUp = 0f;
    public float Second;
    public string currentTime;
    public bool gameInPlay;

    private void OnEnable()
    {
        EventManager.timer += CallTimer;
    }
    private void OnDisable()
    {
        EventManager.timer -= CallTimer;
    }

    void CallTimer()
    {
        StartCoroutine(StartTimer());
    }
    public IEnumerator StartTimer()
    {
        gameInPlay = true;

        while (gameInPlay == true)
        {
            countUp += Time.deltaTime;
            // double b = Math.Round(countUp, 2);

           
            Second = Mathf.FloorToInt(countUp % 60);
            currentTime =  Second.ToString() + " Seconds";
            currentTimeText.text = currentTime;
            yield return null;
        }
        yield return null;
    }
}
