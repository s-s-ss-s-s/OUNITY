using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBlueDoorObstacle : MonoBehaviour
{
    private Collider obstacleCollider;

    void Start()
    {
        obstacleCollider = GetComponent<Collider>(); // Получаем коллайдер объекта
    }

    void Update()
    {
        // Проверяем, есть ли у игрока ключ
        if (OpenBlueDoor.hasKey)
        {
            // Уничтожаем объект через 1 секунду, если у игрока есть ключ
            DestroyObstacle();
        }
    }

    void DestroyObstacle()
    {
        // Отключаем коллайдер, чтобы через объект можно было пройти
        if (obstacleCollider != null)
        {
            obstacleCollider.enabled = false;
        }

        // Разрушаем объект
        Destroy(gameObject, 1f); // Уничтожим объект с задержкой 1 секунда
    }
}