using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект Player
        if (other.CompareTag("Player"))
        {
            // Перезапускаем сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}