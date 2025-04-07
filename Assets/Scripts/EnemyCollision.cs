using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ Player
        if (other.CompareTag("Player"))
        {
            // ������������� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}