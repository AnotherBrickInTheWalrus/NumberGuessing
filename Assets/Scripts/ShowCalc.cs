using UnityEngine;

public class ShowCalc : MonoBehaviour
{
    private bool calcHidden = true;
    
    public void showCalc()
    {
        if (calcHidden)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }

            calcHidden = false;
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }

            calcHidden = true;
        }
    }
    
}
