using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private float _sightRange;
    [SerializeField] private float _walkRange;

    private NavMeshAgent _enemyAgent;
    private Vector3 _walkPoint;
    private bool _walkPointSet;

    private void Awake()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsPlayerInSight())
        {
            MoveToTarget(_playerTransform.position);
        }
        else
        {
            Patrol();
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        _enemyAgent.SetDestination(target);
    }

    private bool IsPlayerInSight()
    {
        Vector3 direction = _playerTransform.position - transform.position;
        Debug.DrawLine(transform.position, transform.position + direction.normalized * _sightRange, Color.magenta);

        // ѕровер€ем, что игрок находитс€ в пределах видимости и нет преп€тствий
        bool playerVisible = Physics.Raycast(transform.position, direction, _sightRange, _playerMask);
        bool obstacleDetected = Physics.Raycast(transform.position, direction, direction.magnitude, ~_playerMask);
        return playerVisible && !obstacleDetected; // »грок видим и нет преп€тствий
    }

    private void Patrol()
    {
        Vector3 directionToPoint = _walkPoint - transform.position;
        if (directionToPoint.magnitude < 1f)
        {
            _walkPointSet = false;
        }

        if (_walkPointSet)
        {
            MoveToTarget(_walkPoint);
        }
        else
        {
            SearchPoint();
        }
    }

    private void SearchPoint()
    {
        float randomOffsetX = Random.Range(-_walkRange, _walkRange);
        float randomOffsetZ = Random.Range(-_walkRange, _walkRange);
        _walkPoint = new Vector3(transform.position.x + randomOffsetX, transform.position.y,
                                  transform.position.z + randomOffsetZ);
        NavMeshPath path = new NavMeshPath();
        _enemyAgent.CalculatePath(_walkPoint, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            _walkPointSet = true;
            Debug.DrawLine(_walkPoint, _walkPoint + Vector3.up * 3, Color.green, 3f); // ѕоднимаем линию дл€ лучшей видимости
        }
        else
        {
            Debug.DrawLine(_walkPoint, _walkPoint + Vector3.up * 3, Color.red, 3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(_walkRange * 2, 1, _walkRange * 2)); // устанавливаем высоту куба
    }
}
/*
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetDestinationToMousePosition();
    }

    private void SetDestinationToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
            _navMeshAgent.SetDestination(hit.point);
    }
}
*/