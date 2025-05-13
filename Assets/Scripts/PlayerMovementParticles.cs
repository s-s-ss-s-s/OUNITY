using UnityEngine;

public class PlayerMovementParticles : MonoBehaviour
{
    // Ссылка на объект с компонентом ParticleSystem
    [SerializeField] private GameObject _particleSystemObject;
    private ParticleSystem _particleSystem;

    private Vector3 _previousVelocity;
    private CharacterController _characterController;

    private void Awake()
    {
        // Получаем компонент ParticleSystem
        if (_particleSystemObject != null)
        {
            _particleSystem = _particleSystemObject.GetComponent<ParticleSystem>();
            if (_particleSystem == null)
            {
                Debug.LogError("На объекте отсутствует компонент ParticleSystem!");
            }
        }
        else
        {
            Debug.LogError("Объект ParticleSystem не назначен в инспекторе!");
        }

        // Получаем CharacterController объекта игрока
        _characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        // Получаем текущую скорость движения игрока
        Vector3 currentVelocity = _characterController.velocity;

        // Проверяем, движется ли игрок
        bool isMoving = currentVelocity.x != 0 || currentVelocity.z != 0;

        // Включаем или выключаем систему частиц в зависимости от того, движется ли игрок
        if (isMoving && !_particleSystem.isPlaying)
        {
            _particleSystem.Play(); // Запускаем частицы при движении
        }
        else if (!isMoving && _particleSystem.isPlaying)
        {
            _particleSystem.Stop(); // Останавливаем частицы, когда игрок стоит
        }

        _previousVelocity = currentVelocity; // Обновляем предыдущее значение скорости
    }
}