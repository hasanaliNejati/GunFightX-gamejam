using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    public bool playOnAwake;
    public bool playAndDestroy;
    public bool randomSpeed;
    public float minPith = 0.7f;
    public float maxPith = 1.3f;
    public AudioClip[] clips;

    AudioSource _audioSource;
    AudioSource audioSource
    {
        get { return _audioSource?_audioSource:_audioSource = GetComponent<AudioSource>(); }
    }

    private void Awake()
    {
        if (playOnAwake)
        {
            print("aaaaaaaaaa");
            if (playAndDestroy)
                PlayAndDestroy();
            else
                Play();
        }
    }

    public void Play()
    {
        if (clips.Length > 0)
            audioSource.clip = clips[Random.Range(0, clips.Length)];
        if (randomSpeed)
        {
            audioSource.pitch = Random.Range(minPith, maxPith);
        }
        audioSource.Play();
    }
    public void PlayAndDestroy()
    {
        transform.parent = null;
        Play();
        Destroy(gameObject, 2);
    }
}
