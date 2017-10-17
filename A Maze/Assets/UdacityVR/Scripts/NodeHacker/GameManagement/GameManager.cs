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
    public AudioClip DecryptedKeyClip;

    // Use this for initialization
    void Awake() {
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
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        mazeGenerator = (MazeGenerator)FindObjectOfType(typeof(MazeGenerator));
        if(mazeGenerator != null) {
            mazeGenerator.sizeX = (int)MazeDifficulty;
            mazeGenerator.sizeZ = (int)MazeDifficulty;
            mazeGenerator.InitializeMaze();
            mazeGenerator.GenerateMaze();
        }        
    }

    public void OnEscapeDoorOpened() {

    }


    public void OnKeyDecrypted() {
        if(DecryptedKeyClip != null) {
            AudioManager.instance.PlaySingle(DecryptedKeyClip);
        }
    }

    public void CompleteLevel() {
        Debug.Log("Won level");
    }

    public void GameOver() {
        Debug.Log("Game Over");
    }
}
