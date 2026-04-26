using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class HoverSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHover = false;
     float hoverAmount = 0.5f;
    Vector2 startPosition;

    private void OnEnable()
    {
        isHover = false;
    }

  
    private void Start()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHover)
        {
            SelectCardHover();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHover == true)
        {
            DeselectCardHover();
        }
    }
    void SelectCardHover()
    {
        isHover = true;

        transform.position = new Vector2(transform.position.x, transform.position.y + hoverAmount);
        
    }

    void DeselectCardHover()
    {
        isHover = false;
        transform.position = new Vector2(transform.position.x, transform.position.y - hoverAmount);
    }
}
