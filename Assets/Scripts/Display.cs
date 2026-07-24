using UnityEngine;
using TMPro;
public class FirstDigit : MonoBehaviour
{
    public void SetDigit(int digit)
    {
        GetComponent<TextMeshProUGUI>().text = digit.ToString();
    }
}
