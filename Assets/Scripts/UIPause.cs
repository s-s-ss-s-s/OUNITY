using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player; // ����� ��� ������, �������� ����������� ������ ����
    private MouseInput mouseInputScript; // ������ ���������� �����

    void Start()
    {
        mouseInputScript = player.GetComponent<MouseInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        // ���������� ���������� �����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ���������, ��� ������ ���� ������� ������ ���� �� �� � ���������
        if (!OpenYellowDoor.IsTerminal)
        {
            mouseInputScript.enabled = true; // �������� ������ ���� �������
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // ������������ ������, ����� ����� ���� ����������������� � �������� UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mouseInputScript.enabled = false; // ��������� ������ ����, ����� ��� �� ������� ������
    }

    public void MainMenu()
    {
        UIGameOver.GameIsOver = true;
        Debug.Log("������� � ������� ����..."); // �������� ������� � ������� ����
        SceneManager.LoadScene("menu"); // ������� � �������� ����
    }
}