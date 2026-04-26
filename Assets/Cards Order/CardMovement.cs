using UnityEngine;
using UnityEngine.Splines;

public class CardMovement : MonoBehaviour
{
    [Header("card Data")]
    [SerializeField] private string cardName;
    [SerializeField] private int cardNumber;

    bool isPlay;

    private Collider2D cardCollider;
    private Vector3 startDragPosition;
    //public bool isFull = false;


    private void OnEnable()
    {
        EventManager.timer += Play;
    }
    private void OnDisable()
    {
        EventManager.timer -= Play;
    }
    private void Start()
    {
        cardCollider = GetComponent<Collider2D>();
    }

    void Play()
    {
        isPlay = true;
    }
    private void OnMouseDown()
    {
        if (cardCollider != null && isPlay == true)
        {
            startDragPosition = transform.position;
            transform.position = GetMousePositionInWorldSpace();
        }
    }
    private void OnMouseDrag()
    {
        if (cardCollider != null && isPlay == true)
        {
            transform.position = GetMousePositionInWorldSpace();
        }
    }
    private void OnMouseUp()
    {

        if (cardCollider != null && isPlay == true)
        {
            cardCollider.enabled = false;
            Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
            cardCollider.enabled = true;
            if (hitCollider != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
            {
                cardDropArea.OnCardDrop(this, cardName, cardNumber);
                //isFull = true;
                cardCollider = null;
               
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
