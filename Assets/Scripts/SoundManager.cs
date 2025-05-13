using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip firstSoundClip;  // ������ ��������� (MP3)
    public AudioClip bgSoundClip; // ������ ��������� (MP3)
    public AudioClip deathSoundClip;
    public static bool gameIsOver = false;

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
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    void Update()
    {
        // ��������� ��������� �������� ����������
        if (targetTransform != null && targetTransform.position.y < -5f && !gameIsOver)
        {
            PlayGameOver();
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
    
}