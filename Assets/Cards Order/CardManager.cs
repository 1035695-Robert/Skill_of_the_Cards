using Unity.Collections;
using UnityEngine;
public class CardManager : MonoBehaviour
{
  public GameObject[] playingCards;

    public InstructionUI ui;
    public GameObject DropZone;
    public void GameStart()
    {
        ui = GameObject.Find("Instruction UI").GetComponent<InstructionUI>();
        ui.StartGame();

       DropZone.SetActive(true);

        Shuffle();
    }
    public void Shuffle() // simple shuffle system by prefixWiz
    {
        playingCards = Resources.LoadAll<GameObject>("NumberCards");
        for (int PositionInIndex = 0; PositionInIndex < playingCards.Length; PositionInIndex++)
        {
            GameObject card = playingCards[PositionInIndex];
            int randomizeArray = Random.Range(0, PositionInIndex);
            playingCards[PositionInIndex] = playingCards[randomizeArray];
            playingCards[randomizeArray] = card;
        }
        
        DealCards dealCards = GetComponent<DealCards>();
        dealCards.StartDealHand(); 
    }
}
#region notes
//fisher-yates Algorithm
#endregion