
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class GameControl : MonoBehaviour
{
    private GuessesList Guesses;
    public string CurrentGuess;
    public int TotalGuesses;
    public int GuessesRemaining;
    public int NumOfDigits;
    public int NumOfRules;
    public int NumOfGivenRules;
    public int LenOfRules;
    public List<string> GuessedNumbers;
    public List<List<bool>> GuessResults;
    public Dictionary<string, Func<int, bool>> UsedRules;
    public Dictionary<string, Func<int, bool>> PossibleRules;
    public List<Dictionary<string, Func<int, bool>>> AllRules;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Guesses = GameObject.Find("PastGuesses").GetComponent<GuessesList>();
        GuessedNumbers = new List<string> { };
        GuessResults = new List<List<bool>> { };
        UsedRules = new Dictionary<string, Func<int, bool>> { };
        Dictionary<string, Func<int, bool>> SumRules = new Dictionary<string, Func<int, bool>> { 
            {"Sum of the digits is less than 10", SumInRange(0, 9)},
            {"Sum of the digits is in the range 10 <= Sum <= 19", SumInRange(10, 19)},
            {"Sum of the digits is a prime number",SumIsPrime},
            {"Sum of the digits is a square number", SumIsSquare},
            {"Sum of the digits is a triangular number", SumIsTriangular},
            {"Sum of the digits is a factor of 100", SumIsFactorOf100},
            {"Sum of the digits has repeated digits", SumIsRepeat}};
        Dictionary<string, Func<int, bool>> DivRules = new Dictionary<string, Func<int, bool>> {
            {"The number is divisible by 4", DivisibleBy(2)},
            {"The number is divisible by 11", DivisibleBy(11)}};
        for (int i = 3; i < 9; i = i + 2) DivRules.Add($"The number is divisible by {i}",DivisibleBy(i));
        Dictionary<string, Func<int, bool>> ContRules = new Dictionary<string, Func<int, bool>> {};
        for (int i = 0; i < 10; i++) ContRules.Add($"The number contains a {i}", Contains(i));
        Dictionary<string, Func<int, bool>> MiscRules = new Dictionary<string, Func<int, bool>> {
            {"The number is a power of 2", IsPowerOf2},
            {"The number is a palindrome", IsPalindrome},
            {"All the digits are even", AllDigitsEven},
            {"All the digits are odd", AllDigitsOdd},
            {"All the digits are primes", AllDigitsPrime},
            {"The product of the digits is a square number", ProductIsSquare},
            {"All the digits are unique", IsPandigital},
            {"None of the digits are unique", NonUnique},
            {"Each digit is greater than the previous", Ascending},
            {"Each digit is smaller than the previous", Descending},
            {"Contains a 'Y' when spelt out", ContainsY},
            {"No adjacent equal digits", NoAdjacentEqual},
            {"Last 2 digits divisible by 8", LastTwoDivisible8},
            {"Last 2 digits divisible by 3", LastTwoDivisible3},
            {"Last 2 digits the same", LastTwoSame},
            {"Has 3 consecutive identical digits", ThreeConsecutiveSame},
            {"Every other digit is the same", EveryOtherSame} };
        AllRules = new List<Dictionary<string, Func<int, bool>>> { SumRules, DivRules, ContRules, MiscRules };
        GenerateRuleSet();
    }

    void Update() { }

    public void digit(int number) {
        if (CurrentGuess.Length < NumOfDigits) {
            CurrentGuess += number.ToString();
            GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = number.ToString();
        }
    }

    public void digitRem() {
        if (CurrentGuess.Length > 0) {
            GameObject.Find($"{CurrentGuess.Length}").GetComponent<TextMeshProUGUI>().text = "";
            CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length - 1);
        }
    }

    public void digitDel() {
        for(int i=1; i<= NumOfDigits; i++){
            GameObject.Find($"{i}").GetComponent<TextMeshProUGUI>().text = "";
        }
        CurrentGuess = "";
    }

    public void addNumToGuesses() {
        if (CurrentGuess.Length == NumOfDigits) {
            GuessedNumbers.Add(CurrentGuess);
        }
    }

    public void AddResultToGuesses(List<bool> result) {
        GuessResults.Add(result);
    }

    public void UpdateResultDisplay(List<bool> result){
        for(int i=0; i< NumOfRules; i++){
            GameObject.Find($"Check{i}").GetComponent<Image>().sprite = Resources.Load<Sprite>($"Check{result[i]}");
        }
    }

    public void CheckRuleValidity(in Dictionary<string, Func<int, bool>> RuleSet, out bool Vailidity, out int count) {
        int maxnum = Convert.ToInt32(new string('9', NumOfDigits));
        count = 0;
        for (int i = 0; i < maxnum + 1; i++) {
            List<bool> result = RuleSet.Select(kvp => kvp.Value(i)).ToList();
            if (!result.Contains(false)) {
                count += 1;
            }
        }
        Vailidity = 10 <= count && count <= 100;
    }

    public Dictionary<string, Func<int, bool>> GenerateTempRuleSet() {
        List<Dictionary<string, Func<int, bool>>> UsedSets = new List<Dictionary<string, Func<int, bool>>> { };
        Dictionary<Dictionary<string, Func<int, bool>>, int> UsedNumber = new Dictionary<Dictionary<string, Func<int, bool>>, int> { };
        Dictionary<string, Func<int, bool>> TempRuleSet = new Dictionary<string, Func<int, bool>> { };
        System.Random rnd = new System.Random();
        if (NumOfRules == 2 || NumOfRules == 3) {
            int randIndex = rnd.Next(AllRules.Count);
            Dictionary<string, Func<int, bool>> ruleset = AllRules[randIndex];
            UsedSets.Add(ruleset);
            var randomElement = ruleset.ElementAt(rnd.Next(ruleset.Count));
            TempRuleSet.Add(randomElement.Key, randomElement.Value);
            for (int i = 1; i <= NumOfRules; i++){
                ruleset = AllRules[rnd.Next(AllRules.Count)];
                while (UsedSets.Contains(ruleset)) {ruleset = AllRules[rnd.Next(AllRules.Count)]; }
                UsedSets.Add(ruleset);
                randomElement = ruleset.ElementAt(rnd.Next(ruleset.Count));
                TempRuleSet.Add(randomElement.Key, randomElement.Value);
            }
        } else if (NumOfRules == 4 || NumOfRules == 5){
            foreach (var item in AllRules){
                UsedNumber.Add(item, 0);
            }
            var randomElement = new KeyValuePair<string, Func<int, bool>> {};
            int randIndex = rnd.Next(AllRules.Count);
            Dictionary<string, Func<int, bool>> ruleset = AllRules[randIndex];
            UsedNumber[ruleset] = 1;
            for (int i = 1; i <= NumOfRules; i++){
                ruleset = AllRules[rnd.Next(AllRules.Count)];
                while (UsedNumber[ruleset] > 1) {ruleset = AllRules[rnd.Next(AllRules.Count)];}
                UsedNumber[ruleset] += 1;
                randomElement = ruleset.ElementAt(rnd.Next(ruleset.Count));
                while (TempRuleSet.Contains(randomElement)){randomElement = ruleset.ElementAt(rnd.Next(ruleset.Count));}
                TempRuleSet.Add(randomElement.Key, randomElement.Value);
            }
        }
        return TempRuleSet;
    }

    public void GenerateRuleSet(){
        int count = 0;
        bool Validity = false;
        UsedRules = new Dictionary<string, Func<int, bool>> { };
        PossibleRules = new Dictionary<string, Func<int, bool>> { };
        Dictionary<string, Func<int,bool>> TempRuleSet = GenerateTempRuleSet();
        CheckRuleValidity(in TempRuleSet, out Validity, out count);
        while (!Validity){
            TempRuleSet = GenerateTempRuleSet();
            CheckRuleValidity(in TempRuleSet, out Validity, out count);
        }
        foreach (var kvp in TempRuleSet){
            UsedRules[kvp.Key] = kvp.Value;
            PossibleRules[kvp.Key] = kvp.Value;
        }
        System.Random rnd = new System.Random();
        var randomElement = new KeyValuePair<string, Func<int,bool>>();
        for (int i=0; i<NumOfGivenRules-NumOfRules; i++){
            Dictionary<string, Func<int,bool>> ruleset = AllRules[rnd.Next(AllRules.Count)];
            randomElement = ruleset.ElementAt(rnd.Next(ruleset.Count));
            if (!PossibleRules.ContainsKey(randomElement.Key)){
                PossibleRules.Add(randomElement.Key, randomElement.Value);
            }
        }
        foreach (var kvp in UsedRules){
            Debug.Log(kvp.Key);
        }
        for (int i=0; i<20; i++){Debug.Log("\n");}
        foreach (var kvp in PossibleRules){
            Debug.Log(kvp.Key);
        }
        Debug.Log(count);
    }

    public void CheckNumber (){
        if (CurrentGuess.Length == NumOfDigits){
            List<bool> result = UsedRules.Select(kvp => kvp.Value(Convert.ToInt32(CurrentGuess))).ToList();
            addNumToGuesses();
            AddResultToGuesses(result);
            UpdateResultDisplay(result);
            Guesses.ListUpdate();
            digitDel();
        }
    }

    public static int SumOfDigits(int x) {
        return x % 10 + x / 10 % 10 + x / 100 % 10 + x / 1000 % 10 + x / 10000 % 10 + x / 100000 % 10;
    }

    public static Func<int, bool> DivisibleBy(int Divisor) {
        Func<int, bool> div;
        return div = x => x % Divisor == 0;
    }

    public Func<int, bool> Contains(int checknum) {
        Func<int, bool> DoesContain;
        return DoesContain = x => (new string('0',NumOfDigits-x.ToString().Length)+x.ToString()).Contains(checknum.ToString());
    }

    public static Func<int, bool> SumInRange(int SumLow, int SumHigh) {
        Func<int, bool> sum;
        return sum = x => SumOfDigits(x) >= SumLow && SumOfDigits(x) <= SumHigh;
    }

    public static bool SumIsPrime(int num) {
        int sum = SumOfDigits(num);
        List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
        return primes.Contains(sum);
    }

    public static bool SumIsSquare(int num) {
        int sum = SumOfDigits(num);
        List<int> squares = new List<int> { 1, 4, 9, 16, 25, 36, 49 };
        return squares.Contains(sum);
    }

    public static bool SumIsTriangular(int num) {
        int sum = SumOfDigits(num);
        List<int> triangles = new List<int> { 1, 3, 6, 10, 15, 21, 28, 36, 45 };
        return triangles.Contains(sum);
    }

    public static bool SumIsRepeat(int num) {
        int sum = SumOfDigits(num);
        return sum % 11 == 0;
    }

    public static bool SumIsFactorOf100(int num) {
        int sum = SumOfDigits(num);
        List<int> factors = new List<int> { 1, 2, 4, 5, 10, 20, 25, 50 };
        return factors.Contains(sum);
    }

    public static bool IsPowerOf2(int num) {
        return Math.Log(num, 2) % 1 == 0;
    }

    public static bool IsPalindrome(int num) {
        string numstring = num.ToString();
        int len = numstring.Length;
        int halflen = len / 2;
        for (int i = 0; i < halflen; i++) {
            if (numstring[i] != numstring[len - i - 1]) {
                return false;
            }
        }
        return true;
    }

    public bool ProductIsSquare(int x) {
        int Prod = 1;
        for (int i = 0; i < NumOfDigits; i++){
            Prod = Prod * (x / Convert.ToInt32(Math.Pow(10, i)) % 10);
        }
        int Squiglette = Convert.ToInt32(Math.Sqrt(Prod));
        return Squiglette*Squiglette == Prod;
    }

    public bool AllDigitsPrime(int x)
    {
        int[] Primes = { 2, 3, 5, 7 };
        int AllPrimes = 1;
        for (int i = 0; i < NumOfDigits; i++)
        {
            AllPrimes = AllPrimes * Convert.ToInt32(Array.Exists(Primes, ele => ele == x / Convert.ToInt32(Math.Pow(10, i)) % 10));
        }
        return AllPrimes == 1;
    }

    public bool AllDigitsOdd(int x)
    {
        int[] Odds = { 1, 3, 5, 7, 9 };
        int AllOdd = 1;
        for (int i = 0; i < NumOfDigits; i++)
        {
            AllOdd = AllOdd * Convert.ToInt32(Array.Exists(Odds, ele => ele == x / Convert.ToInt32(Math.Pow(10, i)) % 10));
        }
        return AllOdd == 1;
    }

    public bool AllDigitsEven(int x)
    {
        int[] Evens = { 2, 4, 6, 8, 0 };
        int AllEven = 1;
        for (int i = 0; i < NumOfDigits; i++)
        {
            AllEven = AllEven * Convert.ToInt32(Array.Exists(Evens, ele => ele == x / Convert.ToInt32(Math.Pow(10, i)) % 10));
        }
        return AllEven == 1;
    }

    public bool IsPandigital(int x) {
        int[] Digits = new int[6];
        for (int i = 0; i < NumOfDigits; i++) {
            int CurrentDigit = x / (Convert.ToInt32(Math.Pow(10, i))) % 10;
            if (Array.Exists(Digits, ele => ele == CurrentDigit)) {
                return false;
            }
            Digits[i] = CurrentDigit;
        }
        return true;
    }

    public bool NonUnique(int x) {
        int[] DigitsOne = new int[7];
        int[] DigitsTwo = new int[7];
        for (int i = 0; i < NumOfDigits; i++) {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (Array.Exists(DigitsOne, ele => ele == CurrentDigit)) {
                DigitsTwo[i] = CurrentDigit;
            }
            else {
                DigitsOne[i] = CurrentDigit;
            }
        }
        foreach (int d in DigitsOne) {
            if (!Array.Exists(DigitsTwo, ele => ele == d)) {
                return false;
            }
        }
        return true;
    }

    public bool Ascending(int x)
    {
        int PrevDigit = x / Convert.ToInt32(Math.Pow(10, 0)) % 10;
        for (int i = 1; i < NumOfDigits; i++)
        {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (!(CurrentDigit < PrevDigit))
            {
                return false;
            }
            PrevDigit = CurrentDigit;
        }
        return true;
    }

    public bool Descending(int x)
    {
        int PrevDigit = x / Convert.ToInt32(Math.Pow(10, 0)) % 10;
        for (int i = 1; i < NumOfDigits; i++)
        {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (!(CurrentDigit > PrevDigit))
            {
                return false;
            }
            PrevDigit = CurrentDigit;
        }
        return true;
    }

    public bool ContainsY(int x)
    {
        int[] OneAnd0 = { 0, 1 };
        if (Array.Exists(OneAnd0, ele => ele == (x / 10) % 10))
        {
            if (NumOfDigits > 4)
            {
                if (Array.Exists(OneAnd0, ele => ele == (x / 10000) % 10))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public bool NoAdjacentEqual(int x)
    {
        int PrevDigit = x % 10;
        for (int i = 1; i < NumOfDigits; i++) {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (CurrentDigit == PrevDigit) {
                return false;
            }
            PrevDigit = CurrentDigit;
        }
        return true;
    }

    public bool LastTwoDivisible3(int x) {
        int Last2 = x % 10 + ((x / 10) % 10) * 10;
        return Last2 % 3 == 0;
    }

    public bool LastTwoDivisible8(int x) {
        int Last2 = x % 10 + ((x / 10) % 10) * 10;
        return Last2 % 8 == 0;
    }

    public bool LastTwoSame(int x) {
        return x % 10 == (x / 10) % 10;
    }

    public bool ThreeConsecutiveSame(int x)
    {
        if (NumOfDigits == 3)
        {
            return false;
        }
        int PrevPrevDigit = x % 10;
        int PrevDigit = (x / 10) % 10;
        for (int i = 2; i < NumOfDigits; i++)
        {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (CurrentDigit == PrevDigit && CurrentDigit == PrevPrevDigit)
            {
                return true;
            }
            PrevPrevDigit = PrevDigit;
            PrevDigit = CurrentDigit;
        }
        return false;
    }

    public bool EveryOtherSame(int x)
    {
        if (NumOfDigits == 3)
        {
            return false;
        }
        int PrevDigit = x % 10;
        bool WorkiesOne = true;
        bool WorkiesTwo = true;
        for (int i = 2; i < NumOfDigits; i = i + 2)
        {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (CurrentDigit != PrevDigit)
            {
                WorkiesOne = false;
            }
            PrevDigit = CurrentDigit;
        }
        PrevDigit = (x / 10) % 10;
        for (int i = 3; i < NumOfDigits; i = i + 2)
        {
            int CurrentDigit = x / Convert.ToInt32(Math.Pow(10, i)) % 10;
            if (CurrentDigit != PrevDigit)
            {
                WorkiesTwo = false;
            }
            PrevDigit = CurrentDigit;
        }
        return WorkiesOne || WorkiesTwo;
    }
}