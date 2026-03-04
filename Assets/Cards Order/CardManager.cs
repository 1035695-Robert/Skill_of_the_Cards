using Unity.Collections;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    [SerializeField] public GameObject[] playingCards;

    private void Awake()
    {
        playingCards = Resources.LoadAll<GameObject>("NumberCards");
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
        
        DealCards dealCards = GetComponent<DealCards>();
        dealCards.DealCardToPlayer();
    }
}

//fisher-yates Algorithm