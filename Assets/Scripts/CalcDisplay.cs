using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.ComponentModel;

public class CalcDisplay : MonoBehaviour
{
    private TextMeshProUGUI box;
    private List<string> operations = new List<string> {"*","/","+","-"};
    private List<string> currentOperation = new List<string> {};
    private string currentNumber;

    private void Start()
    {
        box = GameObject.Find("CalcDisplay").GetComponent<TextMeshProUGUI>();
        box.text = "";
    }

    public void enter(string number)
    {
        if (box.text == "ERROR")
        {
            box.text = "";
        }
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
        float result = 0;
        float firstNum = 0;
        string op = "";
        float secondNum = 0;
        bool opFound = false;
        bool divZero = false;
        for (int i = 0; i < box.text.Length; i++)
        {
            if (operations.Contains(Convert.ToString(box.text[i])))
            {
                Debug.Log(box.text[i]);
                Debug.Log("first" + box.text.Substring(0, i));
                firstNum = float.Parse(box.text.Substring(0, i));
                op = Convert.ToString(box.text[i]);
                Debug.Log("second" + box.text.Substring(i + 1));
                secondNum = float.Parse(box.text.Substring(i + 1));
                opFound = true;
            }
        }

        if (opFound)
        {
            if (op == "*")
            {
                result = firstNum * secondNum;
            }

            else if (op == "/")
            {
                if (secondNum != 0)
                {
                    result = firstNum / secondNum;
                }
                else
                {
                    box.text = "ERROR";
                    divZero = true;
                }
            }

            else if (op == "+")
            {
                result = firstNum + secondNum;
            }

            else if (op == "-")
            {
                result = firstNum - secondNum;
            }

            if (!divZero)
            {
                box.text = Convert.ToString(Math.Round((double)result, 1));
            }

        }

        else
        {
            box.text = "ERROR";
        }

    }

    public void remDigit()
    {

        if (box.text != "")
        {
            box.text = box.text.Substring(0, box.text.Length - 1);
        }
    }
}
