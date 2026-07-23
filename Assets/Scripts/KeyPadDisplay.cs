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
    
    public void digit2()
    {
        text.text += 2.ToString();
    }
    public void digit3()
    {
        text.text += 3.ToString();
    }
    public void digit4()
    {
        text.text += 4.ToString();
    }
    public void digit5()
    {
        text.text += 5.ToString();
    }
    public void digit6()
    {
        text.text += 6.ToString();
    }
    public void digit7()
    {
        text.text += 7.ToString();
    }
}
