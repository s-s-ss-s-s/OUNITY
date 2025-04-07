using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    private void Start()
    {
        Vector3 displacement = new Vector3(3, 0.5f, 3);
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        Instantiate(_cubePrefab, displacement, rotation);
    }
}