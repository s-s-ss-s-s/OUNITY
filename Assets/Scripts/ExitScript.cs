using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Добавляем для работы с сценами

public class ExitScript : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Проверяем, если игра завершена, то ключ отсутствует
        if (UIGameOver.GameIsOver)
        {
            hasKey = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        Debug.Log(hasKey);
        // Если игрок с ключом входит в триггер
        if (other.CompareTag("Player") && hasKey)
        {
            Debug.Log("player");
            // Воспроизведение звука при выходе
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

            // Устанавливаем флаг завершения игры и загружаем сцену меню
            /*Time.timeScale = 0f; // Останавливаем игровое время
            GameIsOver = true; // Устанавливаем состояние игры как завершенное

            // Разблокируем курсор и делаем его видимым
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseInputScript.enabled = false;*/
            UIGameOver.GameIsOver = true;
            //Time.timeScale = 1f;  // Замораживаем время перед загрузкой
            SceneManager.LoadScene("test");
        }
    }
}