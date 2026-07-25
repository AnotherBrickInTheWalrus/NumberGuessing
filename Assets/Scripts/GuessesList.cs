using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GuessesList : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameControl numbers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        numbers = GameObject.Find("GameController").GetComponent<GameControl>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void ListUpdate(){
        text.text += $"{numbers.GuessedNumbers[numbers.GuessedNumbers.Count-1]}";
    }
}
