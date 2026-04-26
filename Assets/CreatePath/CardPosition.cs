using UnityEngine;

public class CardPosition : MonoBehaviour
{
    public GameObject SpawnPrefab;
    private Collider2D col; //to know to get object  
    private Vector3 itemIntitalPoint; //item position
    [SerializeField] private LayerMask layer;
    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown() //on click
    {
        itemIntitalPoint = transform.position; //get position of the card
        transform.position = GetMousePositionWorldSpace();
        Vector3 spawnPosition = GetMousePositionWorldSpace();
        Instantiate(SpawnPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Player have created a card");
    }

    private void OnMouseDrag() //dragging mouse while on pressed
    {
        transform.position = GetMousePositionWorldSpace();

    }

    private void OnMouseUp() //on released
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position, layer);
        Debug.Log(hitCollider);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out DropArea DropArea))
        {
            DropArea.CardDropArea(this);
            gameObject.layer = LayerMask.NameToLayer("ArrowPlayerCollision");
        }
        else 
        {
            transform.position = itemIntitalPoint;
        }
        
    }

    public Vector3 GetMousePositionWorldSpace()
    {
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0f;
            return point;
        }
    }

}
