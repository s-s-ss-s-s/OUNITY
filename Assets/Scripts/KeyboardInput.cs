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

}
