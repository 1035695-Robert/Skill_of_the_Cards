using UnityEngine;

public class HighLow : MonoBehaviour
{
    string selection;

    public void Higher()
    {
        selection = "Higher";
        EventManager.drawCard.Invoke(selection);
    }
    public void Lower() 
    {
        selection = "Lower";
        EventManager.drawCard.Invoke(selection);
    }
}
