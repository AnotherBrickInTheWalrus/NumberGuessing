
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class GameControl : MonoBehaviour
{
    public string CurrentGuess;
    public int GuessesRemaining;
    public int NumOfDigits;
    public int NumOfRules;
    public List <int> GuessedNumbers;
    public List <List<bool>> GuessResults;
    public List <Func<int,bool>> UsedRules;
    public List <Func<int,bool>> PossibleRules;
    public List <List<Func<int,bool>>> AllRules;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GuessedNumbers = new List <int> {};
        GuessResults = new List<List<bool>> {};
        UsedRules = new List <Func<int,bool>> {};
        List<Func<int,bool>> SumRules = new List<Func<int,bool>> {SumInRange(0,10), SumInRange(0,20), SumIsPrime, SumIsSquare, SumIsTriangular, SumIsFactorOf100, SumIsLessThan10, SumIsRepeat};
        List<Func<int,bool>> DivRules = new List<Func<int,bool>> {DivisibleBy(4), DivisibleBy(11)};
        for (int i = 2; i < 9; i=i+2) DivRules.Add(DivisibleBy(i));
        List<Func<int,bool>> ContRules = new List<Func<int,bool>> {};
        for (int i=2;i<10;i++) ContRules.Add(Contains(i));
        List<Func<int,bool>> MiscRules = new List<Func<int,bool>> {IsPowerOf2, IsPalindrome};
        AllRules = new List<List<Func<int,bool>>> {SumRules, DivRules, ContRules, MiscRules};
    }

    void Update(){}

    public void digit(int number){
        if (CurrentGuess.Length < NumOfDigits){
            CurrentGuess += number.ToString();
            GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = number.ToString();
        }
    }

    public void digitRem(){
        GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = "";
        CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length-1);
    }

    public void addNumToGuesses(){
        if (CurrentGuess.Length == NumOfDigits){
            GuessedNumbers.Add(Convert.ToInt32(CurrentGuess));
        }
    }

    public void AddResultToGuesses(List<bool> result){
        GuessResults.Add(result);
    }

    public bool CheckRuleValidity(List<Func<int,bool>> RuleSet){
        int maxnum = Convert.ToInt32(new string('9',NumOfDigits));
        int count = 0;
        for (int i=0; i<maxnum+1; i++){
            List<bool> result = RuleSet.Select(x => x(i)).ToList();
            if (!result.Contains(false)){
                count += 1;
            }
        }
        return count >= 10;
    }

    public List<Func<int,bool>> GenerateRuleSet(){
        List<List<Func<int,bool>>> UsedSets = new List<List<Func<int,bool>>> {};
        List<Func<int,bool>> TempRuleSet = new List<Func<int,bool>> {};
        System.Random rnd = new System.Random();
        if (NumOfRules == 2){
            int randIndex = rnd.Next(AllRules.Count);
            List<Func<int,bool>> ruleset = AllRules[randIndex];
            TempRuleSet.Add(ruleset[rnd.Next(ruleset.Count)]);
            ruleset = AllRules[rnd.Next(AllRules.Count)];
            while (UsedSets.Contains(ruleset)){ruleset = AllRules[rnd.Next(AllRules.Count)];}
            TempRuleSet.Add(ruleset[rnd.Next(ruleset.Count)]);
        }
        return TempRuleSet;
    }

    public static int SumOfDigits(int x){
        return x%10+x/10%10+x/100%10+x/1000%10+x/10000%10+x/100000%10;
    }

    public static Func<int,bool> DivisibleBy(int Divisor){
        Func<int,bool> div;
        return div = x => x % Divisor == 0;
    }

    public static Func<int,bool> Contains(int checknum){
        Func<int,bool> DoesContain;
        return DoesContain = x => x.ToString().Contains(checknum.ToString());
    }

    public static Func<int,bool> SumInRange(int SumLow, int SumHigh){
        Func<int,bool> sum;
        return sum = x => SumOfDigits(x) >= SumLow && SumOfDigits(x) <= SumHigh;
    }

    public static bool SumIsPrime(int num){
        int sum = SumOfDigits(num);
        List<int> primes = new List<int>{2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59};
        return primes.Contains(sum);
    }

    public static bool SumIsSquare(int num){
        int sum = SumOfDigits(num);
        List<int> squares = new List<int>{1,4,9,16,25,36,49};
        return squares.Contains(sum);
    }

    public static bool SumIsTriangular(int num){
        int sum = SumOfDigits(num);
        List<int> triangles = new List<int>{1,3,6,10,15,21,28,36,45};
        return triangles.Contains(sum);
    }

    public static bool SumIsRepeat(int num){
        int sum = SumOfDigits(num);
        return sum%11 == 0;
    }

    public static bool SumIsFactorOf100(int num){
        int sum = SumOfDigits(num);
        List<int> factors = new List<int>{1,2,4,5,10,20,25,50};
        return factors.Contains(sum);
    }

    public static bool SumIsLessThan10(int num){
        int sum = SumOfDigits(num);
        return sum<10;
    }

    public static bool IsPowerOf2(int num){
        return Math.Log(num, 2)%1 == 0;
    }

    public static bool IsPalindrome(int num){
        string numstring = num.ToString();
        int len = numstring.Length;
        int halflen = len/2;
        for (int i=0; i<halflen; i++){
            if (numstring[i] != numstring[len-i-1]){
                return false;
            }
        }
        return true;
    }
}