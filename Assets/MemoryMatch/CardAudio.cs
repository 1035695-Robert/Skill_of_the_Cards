using UnityEditor.Tilemaps;
using UnityEngine;

public class CardAudio : MonoBehaviour
{
    public AudioClip[] flipClip;
   
    public AudioClip[] dropClip;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        flipClip = Resources.LoadAll<AudioClip>("Audio/SilverDubloon/cards-sliding");
        dropClip  = Resources.LoadAll<AudioClip>("Audio/SilverDubloon/dropping-cards");
    }
    private void OnEnable()
    {
        EventManager.dropAudio += DropAudio;
        EventManager.slideAudio += FlipAudio;
    }
    private void OnDisable()
    {
        EventManager.dropAudio -= DropAudio;
        EventManager.slideAudio -= FlipAudio;
    }

    void DropAudio()
    {
        int index = Random.Range(0, dropClip.Length);

        source.PlayOneShot(dropClip[index]);
    }

    void FlipAudio()
    {
        int index = Random.Range(0, flipClip.Length);

        source.PlayOneShot(flipClip[index]);
    }
}
