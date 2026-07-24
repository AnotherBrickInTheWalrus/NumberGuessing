using UnityEngine;

public class FirstDigit : MonoBehaviour
{
    private GameControl Ctrl; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ctrl = (GameObject.Find("GameController")).GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
