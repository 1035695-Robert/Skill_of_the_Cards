using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Splines;

public class DealCardsOrder : MonoBehaviour
{

    [SerializeField] public List<GameObject> myHand;
    [SerializeField] private int myHandSize = 5;

    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private AudioClip[] dealCardsSoundClip;
    private GameObject audioSourceObject;
    private AudioSource audioSource;

    public void OnEnable()
    {     
        EventManager.CardDealer += SetCards;
        audioSourceObject = GameObject.Find("Audio Source");
        audioSource = audioSourceObject.GetComponent<AudioSource>();
    }
    public void OnDisable()
    {
        EventManager.CardDealer -= SetCards;
    }

    void SetCards(GameObject[] cardList)
    {
        StartCoroutine(DealCardToPlayer(cardList));
    }
    IEnumerator DealCardToPlayer(GameObject[] cardList)
    {
        Debug.Log("dealing cards");
        for (int i = 0; i < myHandSize; i++)
        {

            GameObject cardInHand = Instantiate(cardList[i], spawnPoint.position, spawnPoint.rotation);
            myHand.Add(cardInHand);
            cardInHand.name = cardInHand.name.TrimEnd("(Clone)");
            UpdateCardPosition();
            yield return new WaitForSeconds(0.5f);
        }
        EventManager.timer.Invoke();


    }
    void UpdateCardPosition()
    {
        if (myHand.Count == 0)
        {
            return;
        }
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
            //playSound FX
            EventManager.slideAudio.Invoke();
        }

    }
}
