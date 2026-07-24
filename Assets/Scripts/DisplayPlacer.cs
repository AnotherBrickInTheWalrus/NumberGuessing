using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    public Vector2 MidPos;
    private GameControl Control;
    public GameObject Digit;
    private GameObject newDigit;
    public GameObject Background;
    private GameObject newBackground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        for (int currentDigit = 1; currentDigit < Control.NumOfDigits + 1; currentDigit++)
        {
            newDigit = Instantiate(Digit, MidPos, Quaternion.identity);
            newBackground = Instantiate(Background, MidPos, Quaternion.identity);
            newDigit.name = currentDigit.ToString();
            newBackground.transform.parent = GameObject.Find("Canvas").transform;
            newDigit.transform.parent = GameObject.Find("Canvas").transform;
            float pos = MidPos[0] + (currentDigit - 1 - ((Control.NumOfDigits-1)/2f))*(50 + 30);
            newDigit.transform.localPosition = new Vector2(pos, MidPos[1]);
            newBackground.transform.localPosition = new Vector2(pos, MidPos[1]+2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
