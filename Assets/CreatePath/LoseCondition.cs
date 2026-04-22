using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    public bool hasLost = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GameOver");
            ActivateGameOver();
        }
    }

    public void ActivateGameOver()
    {
        Time.timeScale = 0f;
        hasLost = true;
    }
}
