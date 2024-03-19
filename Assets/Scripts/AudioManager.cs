using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip chomp;

    private void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex != 0)
        {
            musicSource.clip = background;
            musicSource.Stop();
        } 
        //if (scene.buildIndex == 1)
        //{
        //    musicSource.clip = background;
        //    musicSource.Play();
        //}
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
