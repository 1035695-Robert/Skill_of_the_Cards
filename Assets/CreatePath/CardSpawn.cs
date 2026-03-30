using UnityEngine;

public class CardSpawn : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public GameObject instantitatedCard;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InstatiateCard();
        }
    }

    private void InstatiateCard()
    {
        GameObject newCard = Instantiate(SpawnPrefab);
        newCard.name = "New Card";

        if (instantitatedCard != null)
        {
            Destroy(newCard);
        }
    }
}
