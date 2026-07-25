using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CalcDisplay : MonoBehaviour
{
    private TextMeshProUGUI box;
    private List<string> operations = new List<string> {"*","/","+","-"};
    private List<string> currentOperation = new List<string> {};
    private string currentNumber;

    private void Start()
    {
        box = GameObject.Find("CalcDisplay").GetComponent<TextMeshProUGUI>();
    }

    public void enter(string number)
    {
        if (operations.Contains(number))
        {
            currentOperation.Add(currentNumber);
            currentNumber = "";
            currentOperation.Add(number);
        }
        else
        {
            currentNumber += number;
        }
        box.text += number;
    }

    public void calculate()
    {
        
    }
}
