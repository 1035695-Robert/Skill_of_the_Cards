using System.Net;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public  GameObject levelSelection;
   public GameObject UIcanvas;
    GameObject title;
    static bool isReturn;
    private void Start()
    {
        levelSelection = GameObject.Find("LevelSelection");
        title = GameObject.Find("MainMenu");
        if (isReturn == true)
        {
            levelSelection.SetActive(true);
            title.SetActive(false);
        }
        else
        {
            levelSelection.SetActive(false);
            title.SetActive(true);
        }
    }

    public void Play()
    {
       title.SetActive(!title.activeSelf);
       levelSelection.gameObject.SetActive(!levelSelection.gameObject.activeSelf);
        isReturn = !isReturn;
    }

    public void Quit()
    {
        Debug.LogError("Quit Game");
       Application.Quit();
    }
   
}
