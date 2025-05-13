using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public static bool gasMask = false;
    public float slowDownFactor = 0.5f; // Коэффициент замедления
    public float normalSpeed = 5f; // Нормальная скорость игрока
    public float slowSpeed = 2f; // Замедленная скорость игрока

    private bool isInSlowZone = false; // Переменная для проверки нахождения в зоне замедления
    private PlayerMovement playerMovement; // Ссылка на скрипт игрока для изменения скорости

    void Start()
    {
        // Получаем компонент PlayerMovement на объекте игрока
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Когда игрок входит в зону (Collider с триггером)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gasMask)
            {
                // Замедляем движение игрока
                playerMovement.SetSpeed(slowSpeed);
                // Отмечаем, что игрок в зоне
                isInSlowZone = true;
            }
        }
    }

    // Когда игрок выходит из зоны
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gasMask) {
                // Возвращаем нормальную скорость
                playerMovement.SetSpeed(normalSpeed);
                // Отмечаем, что игрок вышел из зоны
                isInSlowZone = false;
            }
            
        }
    }
}