using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;

    
    // Use this for initialization
    void Awake() {
        if (instance == null)
            instance = this;
    }
    void OnDestroy() {
        if (instance = this) {
            instance = null;
        }            
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySingle(AudioClip clip) {
        efxSource.clip = clip;
        efxSource.Play();
    }
}
