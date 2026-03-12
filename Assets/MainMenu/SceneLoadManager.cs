using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadScene(string LevelName)
    {
      SceneManager.LoadScene(LevelName);
    }
}

