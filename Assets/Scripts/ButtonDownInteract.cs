using UnityEngine;

public class ButtonDownInteract : MonoBehaviour
{
    private bool activated = false;
    public float lowerSpeed = 1f; // �������� ���������
    public float lowerDistance = 2f; // �� ������� ��������
    private Vector3[] originalPositions; // �������� ������� ��������
    private GameObject[] floorObjects; // ������ �������� ��� ���������
    private bool[] reachedTarget; // ����� ���������� ����

    void Start()
    {
        // ������� ��� ������� � ����� "FloorDown" � ��������� �� �������� �������
        floorObjects = GameObject.FindGameObjectsWithTag("FloorDown");
        originalPositions = new Vector3[floorObjects.Length];
        reachedTarget = new bool[floorObjects.Length];

        for (int i = 0; i < floorObjects.Length; i++)
        {
            if (floorObjects[i] != null)
            {
                originalPositions[i] = floorObjects[i].transform.position;
                reachedTarget[i] = false;
            }
        }
    }

    public void LowerTheFloor()
    {
        if (!activated)
        {
            activated = true;
        }
    }

    void Update()
    {
        if (activated)
        {
            Debug.Log("Button worked");
            for (int i = 0; i < floorObjects.Length; i++)
            {
                if (floorObjects[i] != null && !reachedTarget[i])
                {
                    Vector3 targetPosition = originalPositions[i] - Vector3.up * lowerDistance;
                    floorObjects[i].transform.position = Vector3.MoveTowards(
                        floorObjects[i].transform.position,
                        targetPosition,
                        lowerSpeed * Time.deltaTime
                    );

                    // ���������, �������� �� ������� �������
                    if (Vector3.Distance(floorObjects[i].transform.position, targetPosition) < 0.01f)
                    {
                        reachedTarget[i] = true;
                    }
                }
            }
        }
    }
}