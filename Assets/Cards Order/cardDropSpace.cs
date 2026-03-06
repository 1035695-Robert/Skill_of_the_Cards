using UnityEngine;

public class cardDropSpace : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Card card)
    {
        card.transform.position = transform.position;
        card.transform.rotation = transform.rotation;
        Debug.Log("card Placed Here");
    }
}
