using System.Net;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
     GameObject levelSelection;
   public GameObject UIcanvas;
    GameObject title;
    public GameObject credits;
    static bool isReturn;
    private void Start()
    {
        levelSelection = GameObject.Find("LevelSelection");
        title = GameObject.Find("MainMenu");
        if (isReturn == true)
        {
            levelSelection.SetActive(true);
            title.SetActive(false);
           credits.SetActive(false);
        }
        else
        {
            levelSelection.SetActive(false);
            title.SetActive(true);
            credits.SetActive(false);
        }
    }

    public void Play()
    {
       title.SetActive(!title.activeSelf);
       levelSelection.gameObject.SetActive(!levelSelection.gameObject.activeSelf);
        isReturn = !isReturn;
    }

public void Credits()
    {
        title.SetActive(!title.activeSelf);
        credits.SetActive(!credits.activeSelf);
       
    }
    public void Quit()
    {
        Debug.LogError("Quit Game");
       Application.Quit();
    }
   
}
