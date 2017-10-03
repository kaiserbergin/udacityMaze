using UnityEngine;
using System.Collections;

public class SimonPuzzle : MonoBehaviour
{
    public int roundCount;
    public float startDelay;
    public float blinkDelay;
    public float puzzleTimeLimit;

    private int[] rounds;
    private bool puzzleGameActive;
    private float elapsedTime;
    private int inputCount;

    private void Awake()
    {
        InitiatePuzzle();
    }

    private void InitiatePuzzle()
    {
        rounds = new int[roundCount];
        for (int i = 0; i < rounds.Length; i++)
        {
            rounds[i] = Random.Range(0, 5);
        }
        elapsedTime = 0f;
        puzzleGameActive = false;
        inputCount = 0;
    }

    public void OnSimonCubeClick(int index)
    {
        Debug.Log("Clicked: " + index);        
        if(inputCount < rounds.Length)
        {
            if(rounds[inputCount] == index)
            {
                inputCount++;
                Debug.Log("Input count: " + inputCount);
                OnCorrectChoice();
                if(rounds.Length == inputCount)
                {
                    WinPuzzle();
                }
            }
            else
            {
                OnIncorrectChoice();
                inputCount = 0;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(BeginSimon());
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleGameActive)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > puzzleTimeLimit)
            {
                FailPuzzle();
            }
        }
    }

    private void OnCorrectChoice()
    {
        Debug.Log("Correct Choice");
    }

    private void OnIncorrectChoice()
    {
        Debug.Log("Incorrect Choice");
    }

    void FailPuzzle()
    {
        puzzleGameActive = false;
        Debug.Log("You failed");
    }

    void WinPuzzle()
    {
        puzzleGameActive = false;
        Debug.Log("You won");
    }

    IEnumerator BeginSimon()
    {
        yield return new WaitForSeconds(startDelay);
        for(int i = 0; i < rounds.Length; i++)
        {
            yield return new WaitForSeconds(blinkDelay);
            Debug.Log(i + ". " + rounds[i]);
        }
        puzzleGameActive = true;
    }
}
