using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _characterVelocity;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _groundCheckLayers;
    [SerializeField] private float _jumpHeight;

    private CharacterController _characterController;
    private float _groundCheckDistance;
    private bool _isGrounded;
    

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _groundCheckDistance = _characterController.skinWidth + Physics.defaultContactOffset;
    }

    private void Update()
    {
        GroundCheck();
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _characterVelocity = new Vector3(input.x * _speed, _characterVelocity.y, input.y * _speed);

        if (_isGrounded)
            _characterVelocity.y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
                _characterVelocity.y = Mathf.Sqrt(-2 * Physics.gravity.y * _jumpHeight);
        else
            _characterVelocity.y += Physics.gravity.y * Time.deltaTime;

        _characterController.Move(_characterVelocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        _isGrounded = false;
        Vector3 bottomSphere = transform.position - Vector3.up * _characterController.radius;
        if (Physics.SphereCast(
            bottomSphere, _characterController.radius,
            Vector3.down, out RaycastHit hit, _groundCheckDistance,
            _groundCheckLayers, QueryTriggerInteraction.Ignore))
        {
            _isGrounded = true;
            if (hit.distance > _characterController.skinWidth)
            {
                _characterController.Move(Vector3.down * hit.distance);
            }
        }
    }
}