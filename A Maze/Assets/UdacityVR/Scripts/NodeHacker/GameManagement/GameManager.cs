using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    private int level = 0;
    public enum Difficulty { Easy = 10, Medium = 12, Hard = 15, Insane = 25 };

    public Inventory inventory;
    public MazePlayer MazePlayer;
    public MazeGenerator mazeGenerator;
    public int decryptionFragmentsRequired;
    public int coinsRequiredForHealthBonus;
    public EscapeDoor escapeDoor;
    public Difficulty MazeDifficulty = Difficulty.Easy;

    // Use this for initialization
    void Awake() {
        Debug.Log("AWAKE");
        inventory = new Inventory();
        MazePlayer = new MazePlayer();
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        Debug.Log("OnEnable");
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        mazeGenerator = (MazeGenerator)FindObjectOfType(typeof(MazeGenerator));
        mazeGenerator.sizeX = (int)MazeDifficulty;
        mazeGenerator.sizeZ = (int)MazeDifficulty;
        mazeGenerator.InitializeMaze();
        mazeGenerator.GenerateMaze();
    }


    public void OnKeyDecrypted() {

    }

    public void CompleteLevel() {
        Debug.Log("Won level");
    }

    public void GameOver() {
        Debug.Log("Game Over");
    }
}
