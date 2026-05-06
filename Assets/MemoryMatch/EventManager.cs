using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{
    public delegate void StartingGame();
    public static StartingGame startingGame;

    public delegate void DealingCards(GameObject[] CardList);
    public static DealingCards CardDealer;

    public delegate void WinCondition();
    public static WinCondition winCondtion;

    public delegate void EndCondtion(string gameInfo, int maxCount);
    public static EndCondtion endCondtion;

    //cards Order

    public delegate void StartTimer();
    public static StartTimer timer;

    public delegate void LoseCondition();
    public static LoseCondition loseCondition;

    //memory Match

    public delegate void CardCheck(string type);
    public static CardCheck ChosenCards;

    public delegate void MatchedCards();
    public static MatchedCards SelectedCard;

    public delegate void FailedMatch(int maxTurns);
    public static FailedMatch failed;

    public delegate void LockCards();
    public static LockCards locked;

    public delegate void StartGame();
    public static StartGame startGame;

    public delegate void StarCheck(int count, int maxCount);
    public static StarCheck starCheck;

    public delegate void UnlockCards();
    public static UnlockCards unlock;

    public delegate void DisplayCards(int value);
    public static DisplayCards displayCards;


    public delegate void FlipCardAudio();
    public static FlipCardAudio slideAudio;

    public delegate void DropCardAudio();
    public static DropCardAudio dropAudio;


    //higher lower
    public delegate void DrawCard(string Selection);
    public static DrawCard drawCard;
}
