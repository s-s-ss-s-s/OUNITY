using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // ��������� ��� ������ � �������

public class ExitScript : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;
    public Canvas endGameCanvas;
    public float fadeDuration = 3f; // ����������������� �����
    [SerializeField] public SoundManager soundManager;

    void Start()
    {
        endGameCanvas.enabled = false;
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
            StartCoroutine(FadeInCanvas(endGameCanvas)); // ������ ����� �� Canvas
        }
    }

    // ����� ��� �������� ��������� Canvas
    private IEnumerator FadeInCanvas(Canvas canvas)
    {
        soundManager.EndGame();
        // ��������������� �����
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

        canvas.enabled = true; // �������� Canvas
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>(); // ��������� CanvasGroup, ���� ��� ���
        }

        canvasGroup.alpha = 0f; // ������������� ����� � 0 ��� ������

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // �������� ��������� ������������
            yield return null; // ���� ���������� �����
        }

        canvasGroup.alpha = 1f; // ���������, ��� �����-����� ����� 1 (��������� �������)

        // ���� ���������� ��������������� �����
        yield return new WaitUntil(() => !audioSource.isPlaying);

        // �������� ����
        Debug.Log("exit game");
        Application.Quit();
    }
}