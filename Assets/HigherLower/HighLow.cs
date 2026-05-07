using UnityEngine;

public class HighLow : MonoBehaviour
{
    string selection;
    bool isLocked = true;

    private void OnEnable()
    {
        EventManager.locked += Unlock;
    }
    private void OnDisable()
    {
        EventManager.locked -= Unlock;
    }
    void Unlock()
    {
        isLocked = false;
    }
    public void Higher()
    {
        if (isLocked == false)
        {
            selection = "Higher";
            EventManager.drawCard.Invoke(selection);
        }
       
    }
    public void Lower()
    {
        if (isLocked == false)
        {
            selection = "Lower";
            EventManager.drawCard.Invoke(selection);
        }
    }
}
