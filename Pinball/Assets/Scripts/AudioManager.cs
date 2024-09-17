using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicAudio;
    public GameObject bumperAudio;
    public GameObject switchAudio;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicAudio.Play();
    }

    public void PlayBumperSound(Vector3 spawnPosition)
    {
        GameObject sound = Instantiate(bumperAudio, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchSound(Vector3 spawnPosition)
    {
        GameObject sound = Instantiate(switchAudio, spawnPosition, Quaternion.identity);
    }
}
