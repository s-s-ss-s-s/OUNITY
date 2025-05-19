using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenYellowDoor : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;
    public static bool IsTerminal = false;
    public GameObject player; // Игрок или объект, которому применяется скрипт мыши
    //private MouseInput mouseInputScript; // Скрипт управления мышью
    public GameObject TerminalCanvas;
    public UITerminal uiterminal;
    public static bool PasswordIsCorrect = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //mouseInputScript = player.GetComponent<MouseInput>();
        PasswordIsCorrect = false;
        hasKey = false;
        uiterminal.ResetTerminal();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsTerminal || PasswordIsCorrect)
        {
            ExitTerminal();
        }

        if (UIGameOver.GameIsOver)
        {
            PasswordIsCorrect = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey && !PasswordIsCorrect)
        {
            IsTerminal = true;
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

            TerminalCanvas.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
           // mouseInputScript.enabled = false;

        }
    }

    void ExitTerminal()
    {
        IsTerminal = false;
        TerminalCanvas.SetActive(false);
        Time.timeScale = 1f;

        // Проверяем, не находится ли игра на паузе
        if (!UIPause.GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        uiterminal.ResetTerminal();
    }
}
