using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{

    public delegate void DealingCards(GameObject[] CardList);
    public static DealingCards CardDealer;

   
}
