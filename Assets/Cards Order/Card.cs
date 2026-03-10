using UnityEngine;
using UnityEngine.Splines;

public class Card : MonoBehaviour
{
    [Header("card Data")]
    [SerializeField] private string cardName;
    [SerializeField] private int cardNumber;


    private Collider2D cardCollider;
    private Vector3 startDragPosition;
    public bool isFull = false;
    string cardLock;

    CardManager cardManager;
    private void Start()
    {
        cardCollider = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        if (cardCollider != null)
        {
            startDragPosition = transform.position;
            transform.position = GetMousePositionInWorldSpace();
        }
    }
    private void OnMouseDrag()
    {
        if (cardCollider != null)
        {
            transform.position = GetMousePositionInWorldSpace();
        }
    }

    private void OnMouseUp()
    {

        if (cardCollider != null)
        {
            cardCollider.enabled = false;
            Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
            cardCollider.enabled = true;
            if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
            {
                cardDropArea.OnCardDrop(this, cardName, cardNumber);
                isFull = true;
                cardCollider = null;
                Destroy(hitCollider);
            }
            else
            {
                transform.position = startDragPosition;
            }
        }
    }


    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        return position;
    }



}
