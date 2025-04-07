using UnityEngine;

public class GameLost : MonoBehaviour // ������ �����
{
    public GameObject loseMessage; // ������ UI ��� ��������� � ���������

    private void Start()
    {
        if (loseMessage != null)
        {
            loseMessage.SetActive(false); // �������� ��������� � ������
        }
    }

    private void OnCollisionEnter(Collision collision) // ��������� ������������
    {
        if (collision.gameObject.CompareTag("Enemy")) // ���������, ���� ������������ � ������
        {
            ShowLoseMessage();
        }
    }

    private void ShowLoseMessage()
    {
        if (loseMessage != null)
        {
            loseMessage.SetActive(true); // ���������� ��������� � ���������
        }
    }
}