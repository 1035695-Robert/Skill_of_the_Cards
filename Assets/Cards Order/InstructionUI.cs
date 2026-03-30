using UnityEngine;

public class InstructionUI : MonoBehaviour
{
 public void StartGame()
    {
        GameObject.Find("Instruction UI").SetActive(false);
        
    }
}
