using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GuessesList : MonoBehaviour
{
    public string text;

    public GameControl numbers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>().text;
        numbers = GameObject.Find("GameController").GetComponent<GameControl>();
    }
    // Update is called once per frame
    void Update()
    {
        text = "";
        
        foreach (int entry in numbers.GuessedNumbers)
        {
            text += $"{entry}\n";
        }
    }
}
