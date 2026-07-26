using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
}
