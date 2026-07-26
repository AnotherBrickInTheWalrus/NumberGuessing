using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class ShowRules : MonoBehaviour
{
    private bool active = false;
    public Dictionary<string, Func<int, bool>> rules;

    public void showRules()
    
    {
        foreach (Transform child in this.gameObject.transform)
        {
            if (active == false)
            {
                child.gameObject.SetActive(true);

            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }

        if (active){
            active = false;
        } else {
            rules = GameObject.Find("GameController").GetComponent<GameControl>().PossibleRules;
            int i = 1;
            foreach (var kvp in rules)
            {
                GameObject.Find($"r{i}").GetComponent<TextMeshProUGUI>().text = kvp.Key;
                i++;
            }
            active = true;
        }
    }
}
