using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Transform rotationObject;
    public float sensitivity = 100.0f; // ���������������� ����

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // �������� � ��������� ������ ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // �������� ���� �� ����
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // �������� ������ �� ��������� � �����������
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // ������������ ���� �� ���������

        rotationY += mouseX;

        // ��������� �������� � ������
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = rotation;

        rotationObject.rotation = Quaternion.Euler(0f, rotationY, 0);
    }

    void OnEnable()
    {
        rotationY = rotationObject.rotation.eulerAngles.y;
    }
}
