using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    public Vector2 MidPos;
    private GameControl Control;
    public GameObject Digit;
    private GameObject newDigit;

    private float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Control = GameObject.Find("GameController").GetComponent<GameControl>();
        for (int currentDigit = 1; currentDigit < Control.NumOfDigits + 1; currentDigit++)
        {
            Debug.Log("Create");
            newDigit = Instantiate(Digit, MidPos, Quaternion.identity);
            newDigit.name = currentDigit.ToString();
            newDigit.transform.parent = GameObject.Find("Canvas").transform;
            float pos = MidPos[0] + (currentDigit - 1 - ((Control.NumOfDigits-1)/2f))*(35 + 20);
            newDigit.transform.localPosition = new Vector2(pos, 300f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
