using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour
{	
	public void ResetScene(GameManager.Difficulty difficulty) 
	{
        GameManager.instance.MazeDifficulty = difficulty;
        SceneManager.LoadScene(0);
	}

    public void suckit(float[] data, int channels) {
        
    }
}