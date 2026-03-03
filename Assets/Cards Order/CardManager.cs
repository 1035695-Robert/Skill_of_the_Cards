using Unity.Collections;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] playingCards;

    [SerializeField] private GameObject[] myHand = new GameObject[5];

    private void Awake()
    {
        playingCards = GameObject.FindGameObjectsWithTag("Cards");
        foreach (var card in playingCards)
        {
            card.SetActive(false);
        }
    }

    private void Start()
    {
        Shuffle();
    }
    private void Shuffle() // simple shuffle system by prefixWiz
    {
        for (int PositionInIndex = 0; PositionInIndex < playingCards.Length; PositionInIndex++)
        {
            GameObject obj = playingCards[PositionInIndex];
            int randomizeArray = Random.Range(0, PositionInIndex);
            playingCards[PositionInIndex] = playingCards[randomizeArray];
            playingCards[randomizeArray] = obj;
        }

        DealCardToPlayer();
    }
    void DealCardToPlayer()
    {// have each card 
       
        for (int i = 0; i < myHand.Length; i++)
        {
            playingCards[i].SetActive(true); 
        }
    }
}

//fisher-yates Algorithm