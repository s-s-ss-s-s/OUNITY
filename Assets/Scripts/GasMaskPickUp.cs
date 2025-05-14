using UnityEngine;

public class GasMaskPickUp : MonoBehaviour
{
    public AudioClip pickupSoundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.clip = pickupSoundClip;
                audioSource.volume = 10f;
                audioSource.loop = false;  // ��������� ������������
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource is null, please ensure it's attached to the GameObject.");
            }

            // ������������� ���������� gasMask � true
            SlowZone.gasMask = true;
            SlowZone1.gasMask = true;
            // ������ ������ ���������
            GetComponent<Renderer>().enabled = false;  // ��������� ��������

            // �����������: �� ������ ����� ��������� ���������, ����� �������� ��������� ������������
            GetComponent<Collider>().enabled = false;

            // �����������: ���� ������ ���������� ������ ����� �������
            Invoke("Destroy(gameObject)", 1f);
        }
    }
}