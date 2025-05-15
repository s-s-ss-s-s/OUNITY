using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupYellowKey : MonoBehaviour
{
    public AudioClip pickupSoundClip;
    private AudioSource audioSource;

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

            // Устанавливаем переменную gasMask в true
            OpenYellowDoor.hasKey = true;
            // Делаем объект невидимым
            GetComponent<Renderer>().enabled = false;  // Отключаем рендерер

            // Опционально: вы можете также отключить коллайдер, чтобы избежать повторных столкновений
            GetComponent<Collider>().enabled = false;

            // Опционально: если хотите уничтожить объект после подбора
            Invoke("Destroy(gameObject)", 1f);
        }
    }
}
