using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip chomp;

    private static AudioManager instance;

    private void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
        if(instance == null){ //if this doesn't exist yet, this becomes the instance
            instance = this;
        }else{ //otherwise destroy itself, to not overlap
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();   

    }  

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
