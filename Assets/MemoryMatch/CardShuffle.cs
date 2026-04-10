using UnityEngine;

public class CardShuffle : MonoBehaviour
{
    public string gameFileName;
    public GameObject[] gameCards;


    private void OnEnable()
    {
        EventManager.startingGame += Shuffle;
    }
    private void OnDisable()
    {
        EventManager.startingGame -= Shuffle;
    }

    public void Shuffle()
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
