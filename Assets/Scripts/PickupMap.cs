using UnityEngine;

public class PickupMap : MonoBehaviour
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

            // ������������� ���������� hasMap � true
            UIMapMenu.hasMap = true;
            // ������ ������ ���������
            GetComponent<Renderer>().enabled = false;  // ��������� ��������

            // �����������: �� ������ ����� ��������� ���������, ����� �������� ��������� ������������
            GetComponent<Collider>().enabled = false;

            // �����������: ���� ������ ���������� ������ ����� �������
            Invoke("Destroy(gameObject)", 1f);
        }
    }
}