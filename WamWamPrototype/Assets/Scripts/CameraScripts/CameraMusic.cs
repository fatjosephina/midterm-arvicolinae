using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMusic : MonoBehaviour
{
    private AudioSource music;
    public AudioClip standardMusic;
    public AudioClip powerupMusic;
    public AudioClip winMusic;
    public AudioClip lossMusic;

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = standardMusic;
        music.loop = true;
        music.volume = 0.2f;
        music.Play();
    }

    void Update()
    {
        if (PlayerMovement.isGameWon)
        {
            if (music.clip != winMusic)
            {
                music.Stop();
                music.clip = winMusic;
                music.loop = false;
                music.volume = 1.0f;
                music.Play();
            }
        }

        if (PlayerMovement.isGameOver && !PlayerMovement.isGameWon)
        {
            if (music.clip != lossMusic)
            {
                music.Stop();
                music.clip = lossMusic;
                music.loop = false;
                music.volume = 1.0f;
                music.Play();
            }
        }
        
        if (PlayerMovement.hasIcepop && !PlayerMovement.isGameWon && !PlayerMovement.isGameOver)
        {
            if (music.clip != powerupMusic)
            {
                music.Stop();
                music.clip = powerupMusic;
                music.loop = true;
                music.volume = 0.1f;
                music.Play();
            }
        }
    }
}
