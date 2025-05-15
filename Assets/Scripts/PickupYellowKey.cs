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
                audioSource.loop = false;  // ��������� ������������
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource is null, please ensure it's attached to the GameObject.");
            }

            // ������������� ���������� gasMask � true
            OpenYellowDoor.hasKey = true;
            // ������ ������ ���������
            GetComponent<Renderer>().enabled = false;  // ��������� ��������

            // �����������: �� ������ ����� ��������� ���������, ����� �������� ��������� ������������
            GetComponent<Collider>().enabled = false;

            // �����������: ���� ������ ���������� ������ ����� �������
            Invoke("Destroy(gameObject)", 1f);
        }
    }
}
