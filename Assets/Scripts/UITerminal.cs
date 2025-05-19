using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITerminal : MonoBehaviour
{
    public static bool b1 = false;
    public static bool b2 = false;
    public static bool b3 = false;
    public static bool b4 = false;
    public AudioClip pressSoundClip;
    public AudioClip passwdSoundClip;
    private AudioSource audioSource;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Yellow;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1f; // Игра начинается с нормальной скорости
        Red.SetActive(false);
        Green.SetActive(false);
        Blue.SetActive(false);
        Yellow.SetActive(false);
        OpenYellowDoor.PasswordIsCorrect = false;
    }

    public void Update()
    {
        if (b1 && b2 && b3 && b4 && !OpenYellowDoor.PasswordIsCorrect)
        {
            audioSource.clip = passwdSoundClip;
            audioSource.volume = 10f;
            audioSource.loop = false;  // Отключаем зацикливание
            audioSource.Play();
            OpenYellowDoor.PasswordIsCorrect = true;
            Red.SetActive(false);
            Green.SetActive(false);
            Blue.SetActive(false);
            Yellow.SetActive(false);
            ExitScript.hasKey = true;
        }

        if (UIGameOver.GameIsOver)
        {
            ResetTerminal();
        }
    }

    public void Press_btn()
    {
        audioSource.clip = pressSoundClip;
        audioSource.volume = 10f;
        audioSource.loop = false;  // Отключаем зацикливание
        audioSource.Play();
    }

    public void PressB1()
    {
        if (!b1)
        {
            Red.SetActive(true);
            b1 = true;
        }
    }

    public void PressB2()
    {
        if (b1)
        {
            Green.SetActive(true);
            b2 = true;
        }
    }

    public void PressB3()
    {
        if(b2)
        {
            Blue.SetActive(true);
            b3 = true;
        }
    }

    public void PressB4()
    {
        if(b3)
        {
            Yellow.SetActive(true);
            b4 = true;
        }
    }

    public void ResetTerminal()
    {
        b1 = false;
        b2 = false;
        b3 = false;
        b4 = false;
        Red.SetActive(false);
        Green.SetActive(false);
        Blue.SetActive(false);
        Yellow.SetActive(false);
        OpenYellowDoor.PasswordIsCorrect = false;
    }
}
