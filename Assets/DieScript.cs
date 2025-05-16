using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Die()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // ������ "Destroy(gameObject)" ���������� ��� ������
        Invoke("DestroyObject", 1f);
    }

    // ����� ��� �������� ������� � ��� �������� ��������
    private void DestroyObject()
    {
        Destroy(gameObject); // ������� ���� ������ � ��� ��� �������� �������
    }
}