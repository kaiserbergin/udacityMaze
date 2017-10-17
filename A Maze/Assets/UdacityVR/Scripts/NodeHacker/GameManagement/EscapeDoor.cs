using UnityEngine;
using System.Collections;

public class EscapeDoor : MonoBehaviour {
    public AudioClip lockedAudioClip;
    public AudioClip unlockedAudioClip;
    private bool opening = false;
    private float elapsedTime = 0;
    public float animationTimeInSeconds = 2f;
    public float openedScale = 6f;
    private float distanceToOpen = 0f;
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

    private void Awake() {
        distanceToOpen = openedScale - transform.localScale.x;
    }

    void Update() {
        if(opening) {
            elapsedTime += Time.deltaTime;
            float additiveScale = elapsedTime / animationTimeInSeconds * (openedScale - distanceToOpen);
            if (elapsedTime >= animationTimeInSeconds) {
                opening = false;
                gameObject.SetActive(false);
            }
            transform.localScale = new Vector3(transform.localScale.x + additiveScale, transform.localScale.y, transform.localScale.z + additiveScale);            
        }
    }

    public void OnDoorClicked() {
        if(GameManager.instance.inventory.isEscapeKeyCollected && GameManager.instance.inventory.IsKeyDecrypted()) {
            AudioManager.instance.PlaySingle(unlockedAudioClip);
            opening = true;
        } else if(!GameManager.instance.inventory.isEscapeKeyCollected) {
            Debug.Log("Need key");
            AudioManager.instance.PlaySingle(lockedAudioClip);
        } else if(!GameManager.instance.inventory.IsKeyDecrypted()) {
            AudioManager.instance.PlaySingle(lockedAudioClip);
            Debug.Log("Key not decrypted");
        }
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked
    }

    //public void Unlock() {
    //    if(unlockSound != null) {
    //        AudioManager.instance.PlayAudio(unlockSound);
    //    }        
    //}
}
