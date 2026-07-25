using UnityEngine;
using TMPro;
public class GameInfo : MonoBehaviour
{
    private TextMeshProUGUI DifficultyField;
    public string Difficulty;
    private GameObject CustomDifficulty;
    private bool CurrentlyCustom = false;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        DifficultyField = GameObject.Find("Difficulty").GetComponent<TextMeshProUGUI>();
        CustomDifficulty = GameObject.Find("CustomDifficulty");
    }

    public void setDifficulty()
    {
        if (Difficulty == "Custom")
        {
            CurrentlyCustom = true;
        }
        Difficulty = DifficultyField.text;
        if (Difficulty == "Custom")
        {
            foreach (Transform child in CustomDifficulty.transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        else if (Difficulty != "Custom" && CurrentlyCustom == true)
        {
            foreach (Transform child in CustomDifficulty.transform)
            {
                child.gameObject.SetActive(false);
            }

            CurrentlyCustom = false;
        }
    }
    
    
}
