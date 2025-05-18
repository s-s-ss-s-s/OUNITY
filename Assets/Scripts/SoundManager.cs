using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip firstSoundClip;  // Первый аудиоклип (MP3)
    public AudioClip bgSoundClip; // Второй аудиоклип (MP3)
    public AudioClip deathSoundClip;
    public AudioClip MapSoundClip;
    public static bool gameIsOver = false;
    public static bool mapIsOpen = false;

    private AudioSource audioSource; // Компонент AudioSource
    public Transform targetTransform; // Объект, позицию которого мы будем отслеживать
    private Coroutine soundCoroutine;

    void Start()
    {
        // Получаем компонент AudioSource на этом объекте
        audioSource = gameObject.AddComponent<AudioSource>();

        // Запускаем корутину
        gameIsOver = false;
        if (!gameIsOver)
        {
            soundCoroutine = StartCoroutine(PlaySoundsSequentially());
        }
    }

    private IEnumerator PlaySoundsSequentially()
    {
        // Устанавливаем первый аудиоклип и воспроизводим его
        audioSource.clip = firstSoundClip;
        audioSource.Play();

        // Ждем, пока первый звук не закончится
        yield return new WaitWhile(() => audioSource.isPlaying);

        // После того как первый звук закончился, устанавливаем второй аудиоклип,
        // включаем режим зацикливания и воспроизводим его
        audioSource.clip = bgSoundClip;
        audioSource.loop = true; // Включаем зацикливание
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    void Update()
    {
        if (targetTransform != null && targetTransform.position.y < -5f && !gameIsOver)
        {
            PlayGameOver();
        }

        if (UIMapMenu.IsMap && !mapIsOpen)
        {
            MapMenuBG();
        }
        else if (!UIMapMenu.IsMap && mapIsOpen)
        {
            mapIsOpen = false;
            audioSource.clip = bgSoundClip;
            audioSource.volume = 0.4f;
            audioSource.loop = true;
            audioSource.Play();

        }

        
    }

    public void PlayGameOver()
    {
        if (soundCoroutine != null)
        {
            StopCoroutine(soundCoroutine);
        }
        gameIsOver = true;
        audioSource.clip = deathSoundClip;
        audioSource.volume = 1f;
        audioSource.loop = false;  // Отключаем зацикливание
        audioSource.Play();
    }

    public void MapMenuBG()
    {
        mapIsOpen = true;
        audioSource.clip = MapSoundClip;
        audioSource.volume = 1f;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void EndGame()
    {
        if (soundCoroutine != null)
        {
            StopCoroutine(soundCoroutine);
            audioSource.Stop();
        }
    }

}