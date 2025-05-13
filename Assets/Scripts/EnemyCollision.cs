using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public KeyboardInput keyboardInput;
    public UIGameOver uiGameOver;
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект Player
        if (other.CompareTag("Player"))
        {
            // Перезапускаем сцену
            keyboardInput.ShowGameOverCanvas();
            soundManager.PlayGameOver();
            Invoke("uiGameOver.TriggerGameOver()", 1f);
        }
    }
}