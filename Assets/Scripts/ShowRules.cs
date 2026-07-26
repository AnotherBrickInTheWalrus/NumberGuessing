using UnityEngine;

public class ShowRules : MonoBehaviour
{
    private bool active = false;
    public void showRules()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (active == false)
            {
                child.gameObject.SetActive(true);
                active = true;
            }
            else
            {
                child.gameObject.SetActive(false);
                active = false;
            }
        }
    }
}
