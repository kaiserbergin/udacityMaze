using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public AudioManager audioManager;

    // Use this for initialization
    void Awake()
    {
        if(GameManager.instance == null) {
            Instantiate(gameManager);
        }
        if(GameManager.instance == null) {
            Instantiate(audioManager);
        }
    }
}
