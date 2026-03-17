using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameObject levelSelection;
    GameObject title;
    private void Start()
    {
        levelSelection = GameObject.Find("LevelSelection");
        levelSelection.SetActive(false);

        title = GameObject.Find("MainMenu");
        title.SetActive(true);
    }    

    public void Play()
    {
        title.SetActive(!title.activeSelf);
       levelSelection.SetActive(!levelSelection.activeSelf);
    }
}
