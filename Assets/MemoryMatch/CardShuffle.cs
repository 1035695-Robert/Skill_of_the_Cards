using System.Collections;
using UnityEngine;

public class CardShuffle : MonoBehaviour
{
    public string gameFileName;
    public GameObject[] gameCards;

    public AudioClip[] shufflesounds;
    private GameObject audioSourceObject;
    private AudioSource audioSource;

    private void OnEnable()
    {
        EventManager.startingGame += Shuffle;
    }
    private void OnDisable()
    {
        EventManager.startingGame -= Shuffle;
    }
    private void Start()
    {
        audioSourceObject = GameObject.Find("Audio Source");
        //audioSource = audioSourceObject.GetComponent<AudioSource>();
        shufflesounds = Resources.LoadAll<AudioClip>("Audio/SilverDubloon/shuffle");
    //Shuffle();
    }

    public void Shuffle()
    {
        gameCards = Resources.LoadAll<GameObject>(gameFileName);

        for (int PositionInIndex = 0; PositionInIndex < gameCards.Length; PositionInIndex++)
        {
            GameObject card = gameCards[PositionInIndex];
            int randomizeArray = Random.Range(0, PositionInIndex);
            gameCards[PositionInIndex] = gameCards[randomizeArray];
            gameCards[randomizeArray] = card;
        }
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        //int index = Random.Range(0, shufflesounds.Length);
        //audioSource.clip = shufflesounds[index];
        //audioSource.Play();
        //yield return new WaitForSeconds(audioSource.clip.length);
        yield return null;
        EventManager.CardDealer?.Invoke(gameCards);
    }
}
