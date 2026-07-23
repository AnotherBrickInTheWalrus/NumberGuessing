using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using System;

public class KeyPadDisplay : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject ctrl;
    void Start()
    { 
        text = GetComponent<TextMeshProUGUI>();
        ctrl = GameObject.Find("GameController");
    }

    public void digit(int number)
    {
        if (text.text.Length < ctrl.GetComponent<GameControl>().NumOfDigits)
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

    public void tryNum()
    {
        if (text.text.Length == ctrl.GetComponent<GameControl>().NumOfDigits)
        {
            ctrl.GetComponent<GameControl>().AddNumToGuesses(Convert.ToInt32(text.text));
        }
    }
}
