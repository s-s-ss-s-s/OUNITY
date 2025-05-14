using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public static bool gasMask = false;
    public float slowDownFactor = 0.5f; // ����������� ����������
    public float normalSpeed = 5f; // ���������� �������� ������
    public float slowSpeed = 2f; // ����������� �������� ������
    public AudioClip enterZoneSoundClip;
    public AudioClip enterZonewMaskSoundClip;
    private AudioSource audioSource; // ������ �� ��������� AudioSource

    private bool isInSlowZone = false; // ���������� ��� �������� ���������� � ���� ����������
    private PlayerMovement playerMovement; // ������ �� ������ ������ ��� ��������� ��������
    public GameObject gasMaskCanvas;
    //private UIGameOver gameOver;

    void Start()
    {
        // �������� ��������� PlayerMovement �� ������� ������
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (UIGameOver.GameIsOver)
        {
            gasMask = false;
        }

        // �������������� AudioSource, ���� �� �� ����������
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the GameObject!");
        }
    }


    // ����� ����� ������ � ���� (Collider � ���������)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInSlowZone = true;

            if (!gasMask)
            {
                // ���������, ��� audioSource �� null
                if (audioSource != null)
                {
                    audioSource.clip = enterZoneSoundClip;
                    audioSource.volume = 0.8f;
                    audioSource.loop = false;  // ��������� ������������
                    audioSource.Play();
                }
                else
                {
                    Debug.LogError("AudioSource is null in OnTriggerEnter!");
                }

                // ��������� �������� ������
                playerMovement.SetSpeed(slowSpeed);
                // ��������, ��� ����� � ����
            }
            else {
                if (isInSlowZone)
                {
                    if (audioSource != null)
                    {
                        audioSource.clip = enterZonewMaskSoundClip;
                        audioSource.volume = 0.8f;
                        audioSource.loop = true;  // ��������� ������������
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

    // ����� ����� ������� �� ����
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
                // ���������� ���������� ��������
                playerMovement.SetSpeed(normalSpeed);
                // ��������, ��� ����� ����� �� ����
                isInSlowZone = false;
            }
        }
    }
}