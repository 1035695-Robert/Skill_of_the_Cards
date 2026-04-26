using UnityEngine;
using System.IO;
using TMPro;

public class TimeScore
{
    [SerializeField] float time;
    public TimeScore()
    {

    }
    public TimeScore(string timeData)
    {
        if (!float.TryParse(timeData, out time))
        {
            Debug.LogError("CANNOT convert score to float");
        }
    }
    public string ReturnTimeSaveData()
    {
        string returnData = "Best Time:" + time;
        return returnData;
    }

}
public class TimeScoreText : MonoBehaviour
{
    public TimeScore currentTimeData = new TimeScore();

    public string fileName = "BestTimeSaveData.txt";

    string bestTimeString;
    public string textFileContents;
    public float bestTimeFloat;
    public TextMeshProUGUI bestTimeText;
    //private void Start()
    //{
    //    GetScoreFileContent();
    //}

   
    public void GetScoreFileContent()
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            if (File.Exists(filePath))
            {
                textFileContents = File.ReadAllText(filePath);
                bestTimeString = textFileContents.Replace("Best Time:", "");
                Debug.Log(bestTimeString);
                if (!float.TryParse(bestTimeString, out bestTimeFloat))
                {
                    Debug.LogError("No time exists");
                }
                Debug.Log(textFileContents);
            }
            else
            {
                Debug.LogWarning("file does not exist");
            }
        }
    }

    public void BestTimeCheck(float currentPlayTime)
    {
        GetScoreFileContent();

        if (currentPlayTime < bestTimeFloat)
        {
            Debug.Log("new Best time");
            currentTimeData = new TimeScore(currentPlayTime.ToString("F2"));
            WriteData(currentTimeData.ReturnTimeSaveData());
            bestTimeText.text = "New Record \n" + currentPlayTime.ToString("F2") + " Seconds";
        }
        else
            bestTimeText.text = textFileContents + "    ";
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
}

