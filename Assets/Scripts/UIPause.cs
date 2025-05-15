using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player; // Игрок или объект, которому применяется скрипт мыши
    private MouseInput mouseInputScript; // Скрипт управления мышью

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

        // Возвращаем управление мышью
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Убедитесь, что скрипт мыши включен только если мы не в терминале
        if (!OpenYellowDoor.IsTerminal)
        {
            mouseInputScript.enabled = true; // Включаем скрипт мыши обратно
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Разблокируем курсор, чтобы можно было взаимодействовать с кнопками UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mouseInputScript.enabled = false; // Отключаем скрипт мыши, чтобы она не двигала камеру
    }

    public void MainMenu()
    {
        UIGameOver.GameIsOver = true;
        Debug.Log("Переход в главное меню..."); // Логируем переход в главное меню
        SceneManager.LoadScene("menu"); // Переход к главному меню
    }
}