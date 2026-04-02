using System.Collections;
using System.Data.SqlTypes;
using UnityEngine;

public enum CardTypes
{
    Null,
    Square,
    Triangle,
    Circle,
    Star,
    Heart,
    Diamond,
    Pentagon,
    Cross,
    Arrow
}


public class CardMatch : MonoBehaviour
{
    public CardTypes CardType;
    public float turnDuration = 2.0f;
   

    private void OnMouseDown()
    {
        Debug.Log(CardType);
        StartCoroutine(TurnCardOver());
    }

    IEnumerator TurnCardOver()
    {
        float turnTime = 0;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0,0,0);

        while (turnTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;
            yield return null;
        }
        //invoke turn count +1 
        //when turn count = 2 check cards for match
        //if not match flip back
        yield return null;
    }

    public void ResetCards()
    {
        StartCoroutine(ResetAllCards());
    }

    IEnumerator ResetAllCards()
    {
        float turnTime = 0;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 180, 0);

        while (turnTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, turnTime);

            turnTime += Time.deltaTime;
        }
            
            yield return null;
    }

}
