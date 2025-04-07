 using UnityEngine;
using UnityEngine.AI;

public class ObjectSpawner : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;
    public GameObject prefab; // ������, ������� ����� ��������������
    public Vector2 zoneSize = new Vector2(10, 10); // ������� ������������� ����
    public int rows; // ���������� �����
    public int columns; // ���������� �������
    public float spawnY; // ���������� Y ��� ���� ��������
    public float spacingX; // ���������� ����� ��������� �� ��� X
    public float spacingY; // ���������� ����� ��������� �� ��� Y
    public Vector3 center = new Vector3(0, 0, 0); // ����� ������� ���������

    void Start()
    {
        GenerateObjects();
        _navMeshSurface.BuildNavMesh();
    }

    void GenerateObjects()
    {
        // ��������� �������� � ������ ������ �������
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // ��������� �������� �� ������ �������
                float posX = center.x + (j - columns / 2f) * spacingX;
                float posZ = center.y + (i - rows / 2f) * spacingY;

                Vector3 position = new Vector3(
                    posX,
                    spawnY, // ���������� Y ������� ����������
                    posZ
                );

                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
} 
