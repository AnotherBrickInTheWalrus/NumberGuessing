using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CheckSmallConstructorScript : MonoBehaviour
{
    private GameControl Control;
    public GameObject CheckSmall;
    private GameObject NewCheckSmall;
    public Vector2 LeftPosCheckSmall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LeftPosCheckSmall = gameObject.transform.localPosition;
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        for (int CurrentRule = 0; CurrentRule < Control.NumOfRules; CurrentRule++){
            NewCheckSmall = Instantiate(CheckSmall, LeftPosCheckSmall, Quaternion.identity);
            NewCheckSmall.name = $"CheckSmall_{Control.GuessResults.Count}_{CurrentRule.ToString()}";
            float pos = LeftPosCheckSmall[0] + (CurrentRule)*(20+2);
            NewCheckSmall.transform.parent = GameObject.Find("Canvas").transform;
            NewCheckSmall.transform.localPosition = new Vector2(pos, LeftPosCheckSmall[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
