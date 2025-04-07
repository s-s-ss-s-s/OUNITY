using UnityEngine;

public class GameLost : MonoBehaviour // Создаём класс
{
    public GameObject loseMessage; // Объект UI для сообщения о проигрыше

    private void Start()
    {
        if (loseMessage != null)
        {
            loseMessage.SetActive(false); // Скрываем сообщение в начале
        }
    }

    private void OnCollisionEnter(Collision collision) // Обработка столкновения
    {
        if (collision.gameObject.CompareTag("Enemy")) // Проверяем, если столкновение с врагом
        {
            ShowLoseMessage();
        }
    }

    private void ShowLoseMessage()
    {
        if (loseMessage != null)
        {
            loseMessage.SetActive(true); // Показываем сообщение о проигрыше
        }
    }
}