using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public KeyboardInput keyboardInput;
    public UIGameOver uiGameOver;
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ Player
        if (other.CompareTag("Player"))
        {
            // ������������� �����
            keyboardInput.ShowGameOverCanvas();
            soundManager.PlayGameOver();
            Invoke("uiGameOver.TriggerGameOver()", 1f);
        }
    }
}