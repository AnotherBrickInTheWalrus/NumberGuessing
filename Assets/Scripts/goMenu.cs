using UnityEngine;
using UnityEngine.SceneManagement;

public class goMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void go()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
