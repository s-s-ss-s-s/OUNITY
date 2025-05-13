using UnityEngine;

public class SlowZone1 : MonoBehaviour
{
    public static bool gasMask = false;
    public float slowDownFactor = 0.5f; // ����������� ����������
    public float normalSpeed = 5f; // ���������� �������� ������
    public float slowSpeed = 2f; // ����������� �������� ������
    public AudioClip enterZoneSoundClip;
    private AudioSource audioSource; // ������ �� ��������� AudioSource

    private bool isInSlowZone = false; // ���������� ��� �������� ���������� � ���� ����������
    private PlayerMovement playerMovement; // ������ �� ������ ������ ��� ��������� ��������

    void Start()
    {
        // �������� ��������� PlayerMovement �� ������� ������
        playerMovement = FindObjectOfType<PlayerMovement>();

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
                isInSlowZone = true;
            }
        }
    }

    // ����� ����� ������� �� ����
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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