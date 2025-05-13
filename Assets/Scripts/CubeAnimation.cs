/*using UnityEngine;



public class CubeAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isRotate;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("moving");
        }

    }
}*/

using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource; // ��������� ���������� ��� AudioSource
    private bool isRotate;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // �������� ��������� AudioSource
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("moving");
            PlayAudio(); // ������������� ����� ��� ������� �������
        }
    }

    private void PlayAudio() // ����� ��� ��������������� �����
    {
        if (audioSource != null)
        {
            audioSource.Play(); // ������������� ����
        }
    }
}