using UnityEngine;
using System;
using UnityEngine.SocialPlatforms.Impl;
using Unity.Collections;
using JetBrains.Annotations;
using TMPro;
using System.IO;
public class Time
{
    public Time()
    {

    }
    public Time(string timeData)
    {
        if(!int.TryParse(timeData, out time))
        {
            Debug.LogError("CANNOT convert score to integer");
        }
    }
    public ReturnTimeSaveData()
    {
        string returnData = "Best Time:" + time;
        return returnData;
    }
}
public class TimeManager : MonoBehaviour
{
    public Time currentScoreData = new Time();
    public string fileName = "ScoreSaveData.txt";
    public string textFileContents;
    [SerializeField] private int points;
    private string updatePoints;

    [SerializeField] private TextMeshProUGUI TimeText;

    private void Start()
    {
        GetScoreFileContent();
    }

    void GetScoreFileContent()
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            if (File.Exists(filePath))
            {
                textFileContents = File.ReadAllText(filePath);
                Debug.Log(textFileContents);
                string pointString = textFileContents.TrimStart("Score: ");
                Debug.Log(pointString);
                if (!int.TryParse(pointString, out points))
                {
                    Debug.LogError("couldnt get points");
                }
                TimeText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
                DisplayScore(pointString);
            }
            else
            {
                Debug.LogWarning("file does not exist");
            }
        }
    }

    void WriteData(string dataToWrite)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log(filePath);
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(dataToWrite);
        }
    }

    private void DisplayTime()
    {
        
        if(currentTime > BestTime)

                       updateTime = points.ToString();
            collision.gameObject.SetActive(false);

            DisplayScore(updatePoints);

            currentScoreData = new Score(updatePoints);
            WriteData(currentScoreData.ReturnScoreSaveData());
        }
    }
    private void DisplayScore(string points)
    {
        TimeText.text = "Box Score: " + points;
    }
}
}
