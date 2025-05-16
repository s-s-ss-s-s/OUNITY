using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBlueDoorObstacle : MonoBehaviour
{
    private Collider obstacleCollider;

    void Start()
    {
        obstacleCollider = GetComponent<Collider>(); // �������� ��������� �������
    }

    void Update()
    {
        // ���������, ���� �� � ������ ����
        if (OpenBlueDoor.hasKey)
        {
            // ���������� ������ ����� 1 �������, ���� � ������ ���� ����
            DestroyObstacle();
        }
    }

    void DestroyObstacle()
    {
        // ��������� ���������, ����� ����� ������ ����� ���� ������
        if (obstacleCollider != null)
        {
            obstacleCollider.enabled = false;
        }

        // ��������� ������
        Destroy(gameObject, 1f); // ��������� ������ � ��������� 1 �������
    }
}