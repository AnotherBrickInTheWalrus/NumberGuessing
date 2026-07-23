using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class KeyPadDisplay : MonoBehaviour
{

    public TextMeshProUGUI text;
    void Start()
    { 
        text = GetComponent<TextMeshProUGUI>();
    }

    public void digit(int number)
    {
        if (text.text.Length < 5)
        {
            text.text += number.ToString();
        }
    }
    public void digitRem()
    {
        if (text.text.Length > 0)
        {
            text.text = text.text.Substring(0, text.text.Length - 1);
        }
    }

}
