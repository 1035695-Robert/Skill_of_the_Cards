using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{

    public delegate void DealingCards(GameObject[] CardList);
    public static DealingCards CardDealer;

    public delegate void WinCondition();
    public static WinCondition allCardsMatch;

    //memory Match
    public delegate void StartingGame();
    public static StartingGame startingGame;

    public delegate void CardCheck(string type);
    public static CardCheck CardSelected;

    public delegate void MatchedCards();
    public static MatchedCards SelectedCard;

    public delegate void FailedMatch(int maxTurns);
    public static FailedMatch failedMatch;

    public delegate void LockCards();
    public static LockCards locked;

    public delegate void StartGame();
    public static StartGame startGame;

    public delegate void StarCheck(int matchCount);
    public static StarCheck starCheck;
}
