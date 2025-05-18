using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip firstSoundClip;  // ������ ��������� (MP3)
    public AudioClip bgSoundClip; // ������ ��������� (MP3)
    public AudioClip deathSoundClip;
    public AudioClip MapSoundClip;
    public static bool gameIsOver = false;
    public static bool mapIsOpen = false;

    private AudioSource audioSource; // ��������� AudioSource
    public Transform targetTransform; // ������, ������� �������� �� ����� �����������
    private Coroutine soundCoroutine;

    void Start()
    {
        // �������� ��������� AudioSource �� ���� �������
        audioSource = gameObject.AddComponent<AudioSource>();

        // ��������� ��������
        gameIsOver = false;
        if (!gameIsOver)
        {
            soundCoroutine = StartCoroutine(PlaySoundsSequentially());
        }
    }

    private IEnumerator PlaySoundsSequentially()
    {
        // ������������� ������ ��������� � ������������� ���
        audioSource.clip = firstSoundClip;
        audioSource.Play();

        // ����, ���� ������ ���� �� ����������
        yield return new WaitWhile(() => audioSource.isPlaying);

        // ����� ���� ��� ������ ���� ����������, ������������� ������ ���������,
        // �������� ����� ������������ � ������������� ���
        audioSource.clip = bgSoundClip;
        audioSource.loop = true; // �������� ������������
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
        audioSource.loop = false;  // ��������� ������������
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