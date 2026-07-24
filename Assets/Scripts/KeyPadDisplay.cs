using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using System;

public class KeyPadDisplay : MonoBehaviour
{

    public void digit(int number)
    {

        if (CurrentGuess.Length < NumOfDigits)
        {
            CurrentGuess += number.ToString();
            GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = number.ToString();
        }
    }

    public void digitRem()
    {
        GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = "";
        CurrentGuess = CurrentGuess.Substring(0, ^1);
    }

    public void addNumToGuesses()
    {
        if (CurrentGuess.Length = NumOfDigits)
        {
            GuessedNumbers.Add(CurrentGuess);
        }
    }
}
