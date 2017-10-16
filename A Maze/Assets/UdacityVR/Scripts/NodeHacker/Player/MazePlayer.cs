using UnityEngine;

public class MazePlayer {
    private int healthPoints;

    public MazePlayer() {
        healthPoints = 4;
    }

    public void AddHealthPoints(int healthPoints) {
        this.healthPoints += healthPoints;
        CheckHealthPoints();        
    }

    public void RemoveHealthPoints(int healthPoints) {
        this.healthPoints -= healthPoints;
        CheckHealthPoints();
    }

    public void MultiplyHealthPoints(int healthPoints) {
        this.healthPoints *= healthPoints;
        CheckHealthPoints();
    }

    public void DivideHealthPoints(int healthPoints) {
        this.healthPoints /= healthPoints;
        CheckHealthPoints();
    }

    public void CheckHealthPoints() {
        Debug.Log("HP: " + healthPoints);
        if (healthPoints <= 0) GameManager.instance.GameOver();
    }
}
