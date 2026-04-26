using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool hasSolved = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger: " + other.name); 
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player won");
            hasSolved = true;
        }
    }
}
