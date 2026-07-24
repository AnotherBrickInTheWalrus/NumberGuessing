using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    private Vector2 MidPos = new Vector2(10f, 10f);
    private GameControl Control;
    public GameObject Digit;
    private int NumDigits;
    private GameObject newDigit;
    private int currentDigit = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        newDigit = Instantiate(Digit, MidPos, Quaternion.identity);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
