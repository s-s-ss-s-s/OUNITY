using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public static bool gasMask = false;
    public float slowDownFactor = 0.5f; // Коэффициент замедления
    public float normalSpeed = 5f; // Нормальная скорость игрока
    public float slowSpeed = 2f; // Замедленная скорость игрока
    public AudioClip enterZoneSoundClip;
    public AudioClip enterZonewMaskSoundClip;
    private AudioSource audioSource; // Ссылка на компонент AudioSource

    private bool isInSlowZone = false; // Переменная для проверки нахождения в зоне замедления
    private PlayerMovement playerMovement; // Ссылка на скрипт игрока для изменения скорости
    public GameObject gasMaskCanvas;
    //private UIGameOver gameOver;

    void Start()
    {
        // Получаем компонент PlayerMovement на объекте игрока
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (UIGameOver.GameIsOver)
        {
            gasMask = false;
        }

        // Инициализируем AudioSource, если он не установлен
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the GameObject!");
        }
    }


    // Когда игрок входит в зону (Collider с триггером)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInSlowZone = true;

            if (!gasMask)
            {
                // Проверяем, что audioSource не null
                if (audioSource != null)
                {
                    audioSource.clip = enterZoneSoundClip;
                    audioSource.volume = 0.8f;
                    audioSource.loop = false;  // Отключаем зацикливание
                    audioSource.Play();
                }
                else
                {
                    Debug.LogError("AudioSource is null in OnTriggerEnter!");
                }

                // Замедляем движение игрока
                playerMovement.SetSpeed(slowSpeed);
                // Отмечаем, что игрок в зоне
            }
            else {
                if (isInSlowZone)
                {
                    if (audioSource != null)
                    {
                        audioSource.clip = enterZonewMaskSoundClip;
                        audioSource.volume = 0.8f;
                        audioSource.loop = true;  // Отключаем зацикливание
                        audioSource.Play();
                    }
                    else
                    {
                        Debug.LogError("AudioSource is null in OnTriggerEnter!");
                    }
                    gasMaskCanvas.SetActive(true);
                }
            }

        }
    }

    // Когда игрок выходит из зоны
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gasMask)
            {
                gasMaskCanvas.SetActive(false);
                audioSource.Stop();
                
            }

            if (!gasMask)
            {
                // Возвращаем нормальную скорость
                playerMovement.SetSpeed(normalSpeed);
                // Отмечаем, что игрок вышел из зоны
                isInSlowZone = false;
            }
        }
    }
}