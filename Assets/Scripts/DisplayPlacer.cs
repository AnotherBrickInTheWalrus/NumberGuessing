using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    private float XMidCoord = 10.0f;
    private float YMidCoord = 10.0f;
    private GameControl Control;
    int NumDigits
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
