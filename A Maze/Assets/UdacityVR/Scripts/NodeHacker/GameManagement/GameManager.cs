using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int level = 0;

    public Inventory inventory;
    public int decryptionFragmentsRequired;

    // Use this for initialization
    void Awake()
    {
        inventory = new Inventory();
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void CompleteLevel() {
        Debug.Log("Won level");
    }
}
