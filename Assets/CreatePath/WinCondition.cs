using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public bool hasSolved = false;

    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Something entered the trigger: " + other.name); 
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player won");
            hasSolved = true;

            SceneManager.LoadScene("MainMenu");
        }
    }
}
