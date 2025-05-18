using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;  // Добавляем для работы с сценами

public class ExitScript : MonoBehaviour
{
    public AudioClip openSoundClip;
    private AudioSource audioSource;
    public static bool hasKey = false;
    public Canvas endGameCanvas;
    public float fadeDuration = 3f; // Продолжительность фейда
    [SerializeField] public SoundManager soundManager;

    void Start()
    {
        endGameCanvas.enabled = false;
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
            StartCoroutine(FadeInCanvas(endGameCanvas)); // Запуск фейда на Canvas
        }
    }

    // Метод для плавного появления Canvas
    private IEnumerator FadeInCanvas(Canvas canvas)
    {
        soundManager.EndGame();
        // Воспроизведение звука
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

        canvas.enabled = true; // Включаем Canvas
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>(); // Добавляем CanvasGroup, если его нет
        }

        canvasGroup.alpha = 0f; // Устанавливаем альфа в 0 для начала

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // Линейное изменение прозрачности
            yield return null; // Ждем следующего кадра
        }

        canvasGroup.alpha = 1f; // Убедитесь, что альфа-канал равен 1 (полностью видимый)

        // Ждем завершения воспроизведения аудио
        yield return new WaitUntil(() => !audioSource.isPlaying);

        // Закрытие игры
        Debug.Log("exit game");
        Application.Quit();
    }
}