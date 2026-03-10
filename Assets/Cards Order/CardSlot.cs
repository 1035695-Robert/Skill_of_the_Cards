using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
public class CardSlot : MonoBehaviour
{
    [Header("Card Data")]
    public string cardName;
    public int cardNumber;
    public bool isFull;

 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cards")
        {
            CardValue cardValue = GameObject.Find(collision.transform.name).GetComponent<CardValue>();
            cardName = cardValue.cardName;
            cardNumber = cardValue.cardNumber;

        }
    }
}
