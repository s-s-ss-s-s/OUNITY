 using UnityEngine;
using UnityEngine.AI;

public class ObjectSpawner : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;
    public GameObject prefab; // Префаб, который будет генерироваться
    public Vector2 zoneSize = new Vector2(10, 10); // Размеры прямоугольной зоны
    public int rows; // Количество строк
    public int columns; // Количество колонок
    public float spawnY; // Координата Y для всех объектов
    public float spacingX; // Расстояние между объектами по оси X
    public float spacingY; // Расстояние между объектами по оси Y
    public Vector3 center = new Vector3(0, 0, 0); // Центр области генерации

    void Start()
    {
        GenerateObjects();
        _navMeshSurface.BuildNavMesh();
    }

    void GenerateObjects()
    {
        // Генерация объектов с учетом центра области
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Вычисляем смещение от центра области
                float posX = center.x + (j - columns / 2f) * spacingX;
                float posZ = center.y + (i - rows / 2f) * spacingY;

                Vector3 position = new Vector3(
                    posX,
                    spawnY, // Координата Y остаётся неизменной
                    posZ
                );

                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
} 
