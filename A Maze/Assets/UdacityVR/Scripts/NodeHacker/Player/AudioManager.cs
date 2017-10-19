using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;

    public AudioClip[] bgMusic;

    
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

    public void PlayRandomizedBGMusic() {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, bgMusic.Length);
        if (musicSource.isPlaying) {
            musicSource.Stop();
        }
        //Set the clip to the clip at our randomly chosen index.
        musicSource.clip = bgMusic[randomIndex];

        //Play the clip.
        musicSource.Play();
    }
}
