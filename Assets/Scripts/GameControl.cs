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

    public static Func<int,bool> DivisbleBy(int Divisor){
        Func<int,bool> div;
        return div = x => x % Divisor == 0;
    }

    public static Func<int,bool> SumTo(int Sum){
        Func<int,bool> sum;
        return sum = x => x%10+x/10%10+x/100%10+x/1000%10+x/10000%10+x/10000%10 == Sum;
    }
}
