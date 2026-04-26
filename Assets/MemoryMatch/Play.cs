using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject InstructionUI;
    public GameObject GameUI;

    public void ClickStart()
    {
        InstructionUI.SetActive(false);
        GameUI.SetActive(true);
        EventManager.startingGame.Invoke();
    }
    
}
