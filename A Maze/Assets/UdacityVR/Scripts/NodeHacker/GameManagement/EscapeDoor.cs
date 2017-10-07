using UnityEngine;
using System.Collections;

public class EscapeDoor : MonoBehaviour {

    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
    }

    public void OnDoorClicked() {
        if(GameManager.instance.inventory.isEscapeKeyCollected && GameManager.instance.inventory.IsKeyDecrypted()) {
            GameManager.instance.CompleteLevel();
        } else if(!GameManager.instance.inventory.isEscapeKeyCollected) {
            Debug.Log("Need key");
        } else if(!GameManager.instance.inventory.IsKeyDecrypted()) {
            Debug.Log("Key not decrypted");
        }
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked
    }

    public void Unlock() {
        // You'll need to set "locked" to false here
    }
}
