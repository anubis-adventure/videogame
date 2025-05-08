using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySFXOnTrigger : MonoBehaviour
{
    [Tooltip("The sound effect to play when something enters the trigger")]
    public AudioClip sfxClip;

    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       _audioSource.PlayOneShot(sfxClip);
    }
}
