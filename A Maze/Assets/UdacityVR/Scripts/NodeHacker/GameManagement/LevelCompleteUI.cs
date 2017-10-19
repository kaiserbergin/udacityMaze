using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour {
    public GameObject TrackingTarget;
    public void OnEasyClicked() {
        GameManager.instance.MazeDifficulty = GameManager.Difficulty.Easy;
        SceneManager.LoadScene(0);
    }
    public void OnMediumClicked() {
        GameManager.instance.MazeDifficulty = GameManager.Difficulty.Medium;
        SceneManager.LoadScene(0);
    }
    public void OnHardClicked() {
        GameManager.instance.MazeDifficulty = GameManager.Difficulty.Hard;
        SceneManager.LoadScene(0);
    }

    public void Update() {
        if (gameObject.activeSelf) {
            transform.rotation = Quaternion.LookRotation(transform.position - TrackingTarget.transform.position);
        }
    }
}
