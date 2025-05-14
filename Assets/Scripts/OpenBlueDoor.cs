using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBlueDoor : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (UIGameOver.GameIsOver)
        {
            hasKey = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            if (audioSource != null)
            {
                audioSource.clip = openSoundClip;
                audioSource.volume = 10f;
                audioSource.loop = false;  // Отключаем зацикливание
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource is null, please ensure it's attached to the GameObject.");
            }

        }
    }
}
