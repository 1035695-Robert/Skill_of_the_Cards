using UnityEngine;

public class CardShuffle : MonoBehaviour
{
    public string gameFileName;
    public GameObject[] gameCards;



    public void Start()
    {
        gameCards = Resources.LoadAll<GameObject>(gameFileName);

        for (int PositionInIndex = 0; PositionInIndex < gameCards.Length; PositionInIndex++)
        {
            GameObject card = gameCards[PositionInIndex];
            int randomizeArray = Random.Range(0, PositionInIndex);
            gameCards[PositionInIndex] = gameCards[randomizeArray];
            gameCards[randomizeArray] = card;
        }

        EventManager.CardDealer?.Invoke(gameCards);
    }
}
