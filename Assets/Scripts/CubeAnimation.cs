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
    private AudioSource audioSource; // Добавляем переменную для AudioSource
    private bool isRotate;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("moving");
            PlayAudio(); // Воспроизводим аудио при нажатии клавиши
        }
    }

    private void PlayAudio() // Метод для воспроизведения аудио
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Воспроизводим звук
        }
    }
}