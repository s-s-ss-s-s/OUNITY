using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public static bool GameIsOver = false; // Статическая переменная для отслеживания состояния игры
    //public GameObject gameOverUI; // UI элемент для экрана завершения игры
    public GameObject player; // Игрок или объект, которому применяется скрипт мыши
    private MouseInput mouseInputScript; // Скрипт управления мышью

    void Start()
    {
        mouseInputScript = player.GetComponent<MouseInput>();
        Time.timeScale = 1f; // Игра начинается с нормальной скорости
    }

    public void TriggerGameOver()
    {
        Debug.Log("Игра завершена!"); // Логируем завершение игры
       // gameOverUI.SetActive(true); // Показываем UI завершения игры
        Time.timeScale = 0f; // Останавливаем игровое время
        GameIsOver = true; // Устанавливаем состояние игры как завершенное

        // Разблокируем курсор и делаем его видимым
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
        mouseInputScript.enabled = false; // Отключаем управление мышью
    }

    public void Restart()
    {
        Debug.Log("Перезапуск игры!"); // Логируем перезапуск игры
        //gameOverUI.SetActive(false); // Скрываем экран завершения игры
        Time.timeScale = 1f; // Возобновляем игровое время
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
        mouseInputScript.enabled = true; // Включаем скрипт мыши обратно
    }

    public void MainMenu()
    {
        Debug.Log("Переход в главное меню..."); // Логируем переход в главное меню
        SceneManager.LoadScene("menu"); // Переход к главному меню
    }
}