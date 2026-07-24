using UnityEngine;

public class DisplayPlacer : MonoBehaviour
{
    private Vector2 MidPos = new Vector2(10f, 10f);
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
            //Transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
