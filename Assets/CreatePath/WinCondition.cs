using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool hasSolved = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player won");
            hasSolved = true;
        }
    }
}
