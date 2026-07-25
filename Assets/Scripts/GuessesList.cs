using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GuessesList : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameControl Control;

    public Vector2 LeftPosCheckSmall;
    public GameObject CheckSmallConstructor;
    private GameObject NewCheckSmallConstructor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void ListUpdate(){
        text.text += $"{Control.GuessedNumbers[Control.GuessedNumbers.Count-1]}\n";
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        NewCheckSmallConstructor = Instantiate(CheckSmallConstructor, LeftPosCheckSmall, Quaternion.identity);
        NewCheckSmallConstructor.name = $"CheckSmallBox_{Control.GuessResults.Count}";
        Vector2 pos = new Vector2(LeftPosCheckSmall[0] + (Control.GuessResults.Count > 25 ? 300 : 0), LeftPosCheckSmall[1]+38*(Control.GuessResults.Count-1));
        NewCheckSmallConstructor.transform.parent = GameObject.Find("Canvas").transform;
        NewCheckSmallConstructor.transform.localPosition = pos;
    }
}
