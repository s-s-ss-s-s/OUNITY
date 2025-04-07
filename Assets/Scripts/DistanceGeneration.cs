using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceGeneration : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _cylinderAmount;
    [SerializeField] private GameObject _cylinderPrefab;

    private NavMeshSurface _navMeshSurface;
    private readonly List<Circle> _circles = new List<Circle>();
    private readonly Vector3[] _directions = new Vector3[6];

    private void Start()
    {
        Quaternion rotation = Quaternion.AngleAxis(60f, Vector3.up);
        Vector3 direction = Vector3.forward;

        for (int i = 0; i < 6; i++)
        {
            _directions[i] = direction;
            direction = rotation * direction;
        }

        Vector3 startPosition = new Vector3(0, 0.5f, 0f);
        Circle root = new Circle(_radius, startPosition);

        _circles.Add(root);
        GenerateCircle(root);
        SpawnPrefabAt(_circles);
        _navMeshSurface.BuildNavMesh();
    }

    private void GenerateCircle(Circle root)
    {
        List<Vector3> directions = new List<Vector3>();
        for (int i = 0; i < _directions.Length; i++)
        {
            directions.Add(_directions[i]);
        }

        for (int i = 0; i < _directions.Length; i++)
        {
            Vector3 randomDirection = directions[Random.Range(0, directions.Count)];
            Vector3 nextPoint = root.Point + randomDirection * _radius * 2f;

            directions.Remove(randomDirection);

            if (TryCreateCircleAt(nextPoint))
            {
                Circle circle = new Circle(_radius, nextPoint);
                _circles.Add(circle);
                GenerateCircle(circle);
            }
        }
    }

    private readonly struct Circle
    {
        public readonly float Radius;
        public readonly Vector3 Point;

        public Circle(float radius, Vector3 point)
        {
            Radius = radius;
            Point = point;
        }
    }

    private bool TryCreateCircleAt(Vector3 point)
    {
        if (_circles.Count >= _cylinderAmount) return false;
        foreach (var existingCircle in _circles)
        {
            float sqrDistance = (point - existingCircle.Point).sqrMagnitude;
            if (sqrDistance < existingCircle.Radius * existingCircle.Radius) return false;
        }
        return true;
    }

    private void SpawnPrefabAt(List<Circle> circles)
    {
        foreach (var circle in circles)
        {
            Instantiate(_cylinderPrefab, circle.Point, Quaternion.identity);
        }
    }

}

