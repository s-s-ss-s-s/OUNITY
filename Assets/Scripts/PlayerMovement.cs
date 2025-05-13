using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _characterVelocity;
    [SerializeField] private float _speed = 5f; // ���������� �������� �� ���������
    [SerializeField] private LayerMask _groundCheckLayers;
    [SerializeField] private float _jumpHeight = 2f; // ���������� �������� �� ���������
    [SerializeField] private float _gravityMultiplier = 2f; // ��������� ��� ��������� �������

    private CharacterController _characterController;
    private float _groundCheckDistance;
    private bool _isGrounded;

    public Transform cameraTransform;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _groundCheckDistance = _characterController.skinWidth + Physics.defaultContactOffset;
    }

    private void Update()
    {
        GroundCheck();

        // �������� ���� � ��������� ����������� �������� �� ������ ����������� ������
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // �������� ����������� ����� ������������ ������
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ���� �� y ����������
        forward.y = 0;
        right.y = 0;

        // ������������ ��������
        forward.Normalize();
        right.Normalize();

        // ��������� �������� �������� �� ������ ����� � ����������� ������
        _characterVelocity.x = (right * input.x + forward * input.y).x * _speed;
        _characterVelocity.z = (right * input.x + forward * input.y).z * _speed;

        // ���������� ����������
        if (_isGrounded)
        {
            _characterVelocity.y = 0f;

            // ���������, �������� �� ������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterVelocity.y = Mathf.Sqrt(2 * _jumpHeight * Mathf.Abs(Physics.gravity.y));
            }
        }
        else
        {
            // ���� �� �� �����, ��������� ���������� � ����������
            _characterVelocity.y += Physics.gravity.y * _gravityMultiplier * Time.deltaTime;
        }

        // �������� ����������� ���������
        _characterController.Move(_characterVelocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        _isGrounded = false;
        Vector3 bottomSphere = transform.position + Vector3.down * (_characterController.height / 2 - _characterController.radius);

        if (Physics.SphereCast(
            bottomSphere, _characterController.radius,
            Vector3.down, out RaycastHit hit,
            _groundCheckDistance, _groundCheckLayers, QueryTriggerInteraction.Ignore))
        {
            _isGrounded = true;

            if (hit.point.y < transform.position.y)
            {
                _characterController.Move(Vector3.down * (transform.position.y - hit.point.y));
            }
        }
    }

    // ����� ��� ��������� ��������
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}