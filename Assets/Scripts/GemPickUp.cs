using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUp : MonoBehaviour
{
    [SerializeField]  public AudioClip pickupSoundClip;
    private AudioSource audioSource;
    public GemCollect gemCollect;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.clip = pickupSoundClip;
                audioSource.volume = 10f;
                audioSource.loop = false;  // Отключаем зацикливание
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource is null, please ensure it's attached to the GameObject.");
            }

            // увеличение счетчика на 1 в соответсвующем скрипте
            gemCollect.AddGem();

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            Invoke("Destroy(gameObject)", 1f);
        }
    }
}
