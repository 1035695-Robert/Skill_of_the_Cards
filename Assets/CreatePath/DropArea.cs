using UnityEngine;

public class DropArea : MonoBehaviour
{
    public void CardDropArea(CardPosition card)
    {
        card.transform.position = transform.position;
    }
}
