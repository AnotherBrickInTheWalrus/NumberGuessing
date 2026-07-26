using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Mime;
using TMPro;
using UnityEngine.UI;

public class PlaceRules : MonoBehaviour
{
    public Dictionary<string, Func<int, bool>> rules;
    void Start()
    {
        rules = GameObject.Find("GameController").GetComponent<GameControl>().PossibleRules;

        int i = 1;
        foreach (var kvp in rules)
        {
            GameObject.Find($"r{i}").GetComponent<TextMeshProUGUI>().text = kvp.Key;
            i++;
        }
    }

    public void GuessRule(int rule)
    {
        if (rules.ContainsKey(GameObject.Find($"r{rule}").GetComponent<TextMeshProUGUI>().text))
        {
            GameObject.Find($"rule{rule}").GetComponent<Image>().color = Color.darkGreen;
        }
        else
        {
            GameObject.Find($"rule{rule}").GetComponent<Image>().color = Color.darkRed;
        }
        GameObject.Find("GameController").GetComponent<GameControl>().UpdateGuessesRemaining(1);
    }

}
