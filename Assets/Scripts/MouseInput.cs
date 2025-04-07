using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Transform rotationObject;
    public float sensitivity = 100.0f; // Чувствительность мыши

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Скрываем и фиксируем курсор мыши
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Получаем ввод от мыши
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Вращение камеры по вертикали и горизонтали
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ограничиваем угол по вертикали

        rotationY += mouseX;

        // Применяем вращение к камере
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = rotation;

        rotationObject.rotation = Quaternion.Euler(0f, rotationY, 0);
    }

    void OnEnable()
    {
        rotationY = rotationObject.rotation.eulerAngles.y;
    }
}
