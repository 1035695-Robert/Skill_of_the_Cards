using UnityEngine;

public class cardDropSpace : MonoBehaviour, ICardDropArea
{
    
    public CardPlacementList placementList = new CardPlacementList();
    public void OnCardDrop(Card card, string name, int number)
    {
        card.transform.position = transform.position;
        card.transform.rotation = transform.rotation;
        placementList.placement.Add(new PlacedCards() { cardName = name, cardNumber = number });

        Debug.Log("name" + card.gameObject.name);
        Debug.Log("card Placed Here");
    }
}
