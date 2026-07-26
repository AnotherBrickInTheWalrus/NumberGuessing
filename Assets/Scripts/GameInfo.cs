using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class GameInfo : MonoBehaviour
{
    private TextMeshProUGUI DifficultyField;
    public string Difficulty;
    private GameObject CustomDifficulty;
    private bool CurrentlyCustom = false;
    private int NumDigits;
    private int NumRules;
    private int NumGuesses;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        DifficultyField = GameObject.Find("Difficulty").GetComponent<TextMeshProUGUI>();
        CustomDifficulty = GameObject.Find("CustomDifficulty");
    }

    public void setDifficulty()
    {
        if (Difficulty == "Custom")
        {
            CurrentlyCustom = true;
        }
        Difficulty = DifficultyField.text;
        if (Difficulty == "Custom")
        {
            foreach (Transform child in CustomDifficulty.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        else if (Difficulty != "Custom" && CurrentlyCustom == true)
        {
            foreach (Transform child in CustomDifficulty.transform)
            {
                child.gameObject.SetActive(false);
            }

            CurrentlyCustom = false;
        }
    }

    public void loadNext()
    {
        Difficulty = DifficultyField.text;
        NumGuesses = 10;
        if (Difficulty == "Easy")
        {
            NumDigits = 4;
            NumRules = 2;
        }
        else if (Difficulty == "Medium")
        {
            NumDigits = 5;
            NumRules = 3;
        }
        else if (Difficulty == "Hard")
        {
            NumDigits = 5;
            NumRules = 4;
        }
        else if (Difficulty == "Extreme")
        {
            NumDigits = 6;
            NumRules = 5;
        }
        else if (Difficulty == "Custom")
        {
            NumDigits = Convert.ToInt32(GameObject.Find("CustomDigits").GetComponent<TextMeshProUGUI>().text);
            NumRules = Convert.ToInt32(GameObject.Find("CustomRules").GetComponent<TextMeshProUGUI>().text);
            NumGuesses = Convert.ToInt32(GameObject.Find("CustomGuesses").GetComponent<TextMeshProUGUI>().text);
        }

        SceneManager.LoadScene("1Rule");

    }

    public List<int> GetParameters()
    {
        return new List<int> { NumDigits, NumRules, NumGuesses };
    }
    
    
    
    
}
