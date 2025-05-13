using UnityEngine;

public class PlayerMovementParticles : MonoBehaviour
{
    // ������ �� ������ � ����������� ParticleSystem
    [SerializeField] private GameObject _particleSystemObject;
    private ParticleSystem _particleSystem;

    private Vector3 _previousVelocity;
    private CharacterController _characterController;

    private void Awake()
    {
        // �������� ��������� ParticleSystem
        if (_particleSystemObject != null)
        {
            _particleSystem = _particleSystemObject.GetComponent<ParticleSystem>();
            if (_particleSystem == null)
            {
                Debug.LogError("�� ������� ����������� ��������� ParticleSystem!");
            }
        }
        else
        {
            Debug.LogError("������ ParticleSystem �� �������� � ����������!");
        }

        // �������� CharacterController ������� ������
        _characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        // �������� ������� �������� �������� ������
        Vector3 currentVelocity = _characterController.velocity;

        // ���������, �������� �� �����
        bool isMoving = currentVelocity.x != 0 || currentVelocity.z != 0;

        // �������� ��� ��������� ������� ������ � ����������� �� ����, �������� �� �����
        if (isMoving && !_particleSystem.isPlaying)
        {
            _particleSystem.Play(); // ��������� ������� ��� ��������
        }
        else if (!isMoving && _particleSystem.isPlaying)
        {
            _particleSystem.Stop(); // ������������� �������, ����� ����� �����
        }

        _previousVelocity = currentVelocity; // ��������� ���������� �������� ��������
    }
}