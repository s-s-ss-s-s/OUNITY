using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // ��������� ��� ������ � �������

public class ExitScript : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // ���������, ���� ���� ���������, �� ���� �����������
        if (UIGameOver.GameIsOver)
        {
            hasKey = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        Debug.Log(hasKey);
        // ���� ����� � ������ ������ � �������
        if (other.CompareTag("Player") && hasKey)
        {
            Debug.Log("player");
            // ��������������� ����� ��� ������
            if (audioSource != null)
            {
                audioSource.clip = openSoundClip;
                audioSource.volume = 10f;
                audioSource.loop = false;  // ��������� ������������
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource is null, please ensure it's attached to the GameObject.");
            }

            // ������������� ���� ���������� ���� � ��������� ����� ����
            /*Time.timeScale = 0f; // ������������� ������� �����
            GameIsOver = true; // ������������� ��������� ���� ��� �����������

            // ������������ ������ � ������ ��� �������
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseInputScript.enabled = false;*/
            UIGameOver.GameIsOver = true;
            //Time.timeScale = 1f;  // ������������ ����� ����� ���������
            SceneManager.LoadScene("test");
        }
    }
}