using UnityEngine;
using System;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{
    public int GuessesRemaining;
    public int NumOfDigits;
    public int NumOfRules;
    public List <int> GuessedNumbers;
    public List <List<bool>> GuessResults;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GuessedNumbers = new List <int> {};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
