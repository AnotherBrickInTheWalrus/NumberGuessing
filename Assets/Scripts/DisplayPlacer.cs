using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    public Vector2 MidPos = new Vector2(-290f, 180f);
    private GameControl Control;
    public GameObject Digit;
    private GameObject newDigit;
    void test()
    {
        
    }
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
            newDigit.transform.localPosition = MidPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
