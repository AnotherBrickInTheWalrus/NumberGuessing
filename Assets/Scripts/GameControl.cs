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

    public static int SumOfDigits(int num){
        return x%10+x/10%10+x/100%10+x/1000%10+x/10000%10+x/10000%10;
    }

    public static Func<int,bool> DivisbleBy(int Divisor){
        Func<int,bool> div;
        return div = x => x % Divisor == 0;
    }

    public static Func<int,bool> SumInRange(int SumLow, int SumHigh){
        Func<int,bool> sum;
        return sum = x => SumOfDigits(x) >= SumLow && SumOfDigits(x) <= SumHigh;
    }

    public static bool SumIsPrime(int num){
        int sum = SumOfDigits(num);
        List<int> squares = new List<int>{2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59};
        return squares.Contains(sum);
    }
}
