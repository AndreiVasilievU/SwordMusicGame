using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip[] soundClips;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnPlaySound(int soundNumber)
    {
        soundSource.PlayOneShot(soundClips[soundNumber]);
    }
}
