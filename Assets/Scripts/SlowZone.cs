using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public static bool gasMask = false;
    public float slowDownFactor = 0.5f; // ����������� ����������
    public float normalSpeed = 5f; // ���������� �������� ������
    public float slowSpeed = 2f; // ����������� �������� ������

    private bool isInSlowZone = false; // ���������� ��� �������� ���������� � ���� ����������
    private PlayerMovement playerMovement; // ������ �� ������ ������ ��� ��������� ��������

    void Start()
    {
        // �������� ��������� PlayerMovement �� ������� ������
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // ����� ����� ������ � ���� (Collider � ���������)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gasMask)
            {
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
            if (!gasMask) {
                // ���������� ���������� ��������
                playerMovement.SetSpeed(normalSpeed);
                // ��������, ��� ����� ����� �� ����
                isInSlowZone = false;
            }
            
        }
    }
}