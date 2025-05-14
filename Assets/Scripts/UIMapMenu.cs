using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMapMenu : MonoBehaviour
{
    public static bool IsMap = false;
    public static bool hasMap = false;
    public GameObject mapMenuUI;
    public GameObject player; // ����� ��� ������, �������� ����������� ������ ����
    private MouseInput mouseInputScript; // ������ ���������� �����
    public GameObject MapCanvas;

    void Start()
    {
        //mouseInputScript = player.GetComponent<MouseInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && hasMap)
        {
            if (IsMap)
            {
                CloseMap();
            }
            else
            {
                OpenMap();
            }
        }
    }

    public void CloseMap()
    {
        MapCanvas.SetActive(false);
        mapMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsMap = false;

        // ���������� ���������� ����� ����� ������������� ����
        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        //mouseInputScript.enabled = true; // �������� ������ ���� �������
    }

    void OpenMap()
    {
        MapCanvas.SetActive(true);
        mapMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsMap = true;
    }
}