using UnityEngine;

public class GasMaskPickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tuk");
            // ������������� ���������� gasMask � true
            SlowZone.gasMask = true;

            // ������ ������ ���������
            GetComponent<Renderer>().enabled = false;  // ��������� ��������

            // �����������: �� ������ ����� ��������� ���������, ����� �������� ��������� ������������
            GetComponent<Collider>().enabled = false;

            // �����������: ���� ������ ���������� ������ ����� �������
            Destroy(gameObject);
        }
    }
}