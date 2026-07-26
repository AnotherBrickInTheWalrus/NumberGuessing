using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Mime;
using TMPro;
using UnityEngine.UI;

public class PlaceRules : MonoBehaviour
{
    public Dictionary<string, Func<int, bool>> rules;
    public Dictionary<string, Func<int, bool>> usedRules;
    void Start()
    {
        rules = GameObject.Find("GameController").GetComponent<GameControl>().PossibleRules;
        usedRules = GameObject.Find("GameController").GetComponent<GameControl>().UsedRules;
    }

    public void GuessRule(int rule)
    {
        if (usedRules.ContainsKey(GameObject.Find($"r{rule}").GetComponent<TextMeshProUGUI>().text))
        {
            GameObject.Find($"rule{rule}").GetComponent<Image>().color = Color.green;
        }
        else
        {
            GameObject.Find($"rule{rule}").GetComponent<Image>().color = Color.red;
        }
        GameObject.Find("GameController").GetComponent<GameControl>().UpdateGuessesRemaining(1);
    }

    public void Flag(int rule)
    {
        Image colour = GameObject.Find($"rule{rule}").GetComponent<Image>();
        if (colour.color != Color.green && colour.color != Color.red)
        {
            if (colour.color != Color.yellow)
            {
                colour.color = Color.yellow;
            }
            else
            {
                colour.color = Color.white;
            }
        }
    }

}
