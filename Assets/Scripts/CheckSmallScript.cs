using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class CheckSmallScript : MonoBehaviour
{
    public List<bool> result;
    private GameControl Control;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        result = Control.GuessResults[Control.GuessResults.Count-1];
        Debug.Log(result.Count);
        Debug.Log(Convert.ToInt32((gameObject.name[gameObject.name.Length-1]).ToString()));
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Check{result[Convert.ToInt32((gameObject.name[gameObject.name.Length-1]).ToString())]}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
