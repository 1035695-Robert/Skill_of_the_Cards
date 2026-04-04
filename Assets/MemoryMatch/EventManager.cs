using UnityEngine;

public class EventManager
{

    public delegate void DealingCards(GameObject[] CardList);
    public static DealingCards CardDealer;

    //memory Match
    public delegate void CardCheck(string type);
    public static CardCheck CardSelected;

    public delegate void MatchedCards();
    public static MatchedCards SelectedCard;

    public delegate void FailedMatch();
    public static FailedMatch failed;

    public delegate void LockCards();
    public static LockCards locked;
}
