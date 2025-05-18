using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    public Transform cameraTransform;
    public Canvas gameOverCanvas; // Ссылка на ваш Canvas для завершения игры
    public float fadeDuration = 1f; // Время для плавного появления канваса
    public UIGameOver gameOverScript; // Ссылка на скрипт UIGameOver

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main != null ? Camera.main.transform : null;
            if (cameraTransform == null)
            {
                Debug.LogError("Camera transform not found!");
            }
        }
        gameOverCanvas.enabled = false;
    }

    void Update()
    {
        // Проверка на падение ниже порога
        if (transform.position.y < -5f)
        {
            ShowGameOverCanvas(); 
        }
    }

    private void Interact()
    {
        RaycastHit hit;
        if (cameraTransform == null)
        {
            return;
        }

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 7f))
        {
            if (hit.collider.CompareTag("button"))
            {
                hit.collider.GetComponent<ButtonDownInteract>().LowerTheFloor();
            }
        }
    }

    public void ShowGameOverCanvas()
    {
        if (gameOverCanvas != null)
        {
            StartCoroutine(FadeInCanvas(gameOverCanvas));
        }
    }

    private IEnumerator FadeInCanvas(Canvas canvas)
    {
        canvas.enabled = true; // Включаем Canvas
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>(); // Добавляем CanvasGroup, если его нет
        }

        canvasGroup.alpha = 0f; // Устанавливаем альфа в 0 для начала

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // Линейное изменение прозрачности
            yield return null; // Ждем следующего кадра
        }

        canvasGroup.alpha = 1f; // Убедитесь, что альфа-канал равен 1 (полностью видимый)
        if (gameOverScript != null)
        {
            gameOverScript.TriggerGameOver(); // Вызываем завершение игры
        }
    }
}
