using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class DealCards : MonoBehaviour
{
    public CardManager cardManager;

    [SerializeField] public List<GameObject> myHand;
    [SerializeField] private int myHandSize = 5;
    public GameObject card;


    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;


    public void StartDealHand()
    {
       StartCoroutine (DealCardToPlayer());
        Debug.Log("DealCards to player");
    }
    IEnumerator DealCardToPlayer()
    {
       cardManager = GetComponent<CardManager>();
        for (int i = 0; i < myHandSize; i++)
        {
            
            GameObject cardInHand = Instantiate(cardManager.playingCards[i], spawnPoint.position, spawnPoint.rotation);
            myHand.Add(cardInHand);
            cardInHand.name = cardInHand.name.TrimEnd("(Clone)");
            UpdateCardPosition();
            yield return new WaitForSeconds(0.5f);
        }
         
        
    }
    void UpdateCardPosition()
    {
        if (myHand.Count == 0)
            return;
        float cardSpacing = 1f / myHandSize;
        float firstCardPosition = 0.5f - (myHand.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;
        for (int i = 0; i < myHand.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);

            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            myHand[i].transform.DOMove(splinePosition, 0.25f);
            myHand[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }
}
