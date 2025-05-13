using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    public Transform cameraTransform;
    public Canvas gameOverCanvas; // ������ �� ��� Canvas ��� ���������� ����
    public float fadeDuration = 1f; // ����� ��� �������� ��������� �������
    public UIGameOver gameOverScript; // ������ �� ������ UIGameOver

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

        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false; // ������� �������� Canvas
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        // �������� �� ������� ���� ������
        if (transform.position.y < -5f)
        {
            ShowGameOverCanvas(); // ������ ������������ ����� ���������� ������
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

    private void ShowGameOverCanvas()
    {
        if (gameOverCanvas != null)
        {
            StartCoroutine(FadeInCanvas(gameOverCanvas));
        }
    }

    private IEnumerator FadeInCanvas(Canvas canvas)
    {
        canvas.enabled = true; // �������� Canvas
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = canvas.gameObject.AddComponent<CanvasGroup>(); // ��������� CanvasGroup, ���� ��� ���
        }

        canvasGroup.alpha = 0f; // ������������� ����� � 0 ��� ������

        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration); // �������� ��������� ������������
            yield return null; // ���� ���������� �����
        }

        canvasGroup.alpha = 1f; // ���������, ��� �����-����� ����� 1 (��������� �������)
        if (gameOverScript != null)
        {
            gameOverScript.TriggerGameOver(); // �������� ���������� ����
        }
    }
}
/*
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class KeyboardInput : MonoBehaviour
{

    public Transform cameraTransform;

    void Start()
    {

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main != null ? Camera.main.transform : null;
            if (cameraTransform == null)
            {
            }
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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

}*/
