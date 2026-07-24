using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    public Vector2 MidPosDigit;
    public Vector2 MidPosCheck;
    private GameControl Control;
    public GameObject Digit;
    private GameObject newDigit;
    public GameObject Background;
    private GameObject newBackground;
    public GameObject CheckBig;
    private GameObject NewCheckBig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        for (int currentDigit = 1; currentDigit < Control.NumOfDigits + 1; currentDigit++)
        {
            newDigit = Instantiate(Digit, MidPosDigit, Quaternion.identity);
            newBackground = Instantiate(Background, MidPosDigit, Quaternion.identity);
            newDigit.name = currentDigit.ToString();
            newBackground.transform.parent = GameObject.Find("Canvas").transform;
            newDigit.transform.parent = GameObject.Find("Canvas").transform;
            float pos = MidPosDigit[0] + (currentDigit - 1 - ((Control.NumOfDigits-1)/2f))*(50 + 40);
            newDigit.transform.localPosition = new Vector2(pos, MidPosDigit[1]);
            newBackground.transform.localPosition = new Vector2(pos, MidPosDigit[1]+2);
        }

        for (int CurrentRule = 0; CurrentRule < Control.NumOfRules; CurrentRule++){
            NewCheckBig = Instantiate(CheckBig, MidPosCheck, Quaternion.identity);
            NewCheckBig.name = $"Check{CurrentRule.ToString()}";
            float pos = MidPosCheck[0] + (CurrentRule - (Control.NumOfRules-1)/2f)*(50+50);
            NewCheckBig.transform.parent = GameObject.Find("Canvas").transform;
            NewCheckBig.transform.localPosition = new Vector2(pos, MidPosCheck[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
