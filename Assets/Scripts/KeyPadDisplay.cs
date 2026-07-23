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

    public void digit1()
    {
        text.text += 1.ToString();
    }
}
