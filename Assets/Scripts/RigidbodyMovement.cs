using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public float speedForce;
    public Rigidbody cubeRigidbody;

    private void Start()
    {
        cubeRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cubeRigidbody.AddForce(speedForce * Time.deltaTime * input, ForceMode.Impulse);
    }
}