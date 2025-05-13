using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public static bool GameIsOver = false; // ����������� ���������� ��� ������������ ��������� ����
    //public GameObject gameOverUI; // UI ������� ��� ������ ���������� ����
    public GameObject player; // ����� ��� ������, �������� ����������� ������ ����
    private MouseInput mouseInputScript; // ������ ���������� �����

    void Start()
    {
        mouseInputScript = player.GetComponent<MouseInput>();
        Time.timeScale = 1f; // ���� ���������� � ���������� ��������
    }

    public void TriggerGameOver()
    {
        Debug.Log("���� ���������!"); // �������� ���������� ����
       // gameOverUI.SetActive(true); // ���������� UI ���������� ����
        Time.timeScale = 0f; // ������������� ������� �����
        GameIsOver = true; // ������������� ��������� ���� ��� �����������

        // ������������ ������ � ������ ��� �������
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
        mouseInputScript.enabled = false; // ��������� ���������� �����
    }

    public void Restart()
    {
        Debug.Log("���������� ����!"); // �������� ���������� ����
        //gameOverUI.SetActive(false); // �������� ����� ���������� ����
        Time.timeScale = 1f; // ������������ ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
        mouseInputScript.enabled = true; // �������� ������ ���� �������
    }

    public void MainMenu()
    {
        Debug.Log("������� � ������� ����..."); // �������� ������� � ������� ����
        SceneManager.LoadScene("menu"); // ������� � �������� ����
    }
}