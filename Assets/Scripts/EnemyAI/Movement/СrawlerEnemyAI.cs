using UnityEngine;

public class СrawlerEnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _movementSpeed;

    private int _currentWaypoint = 0;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) <= 1)
        {
            if (_currentWaypoint == _waypoints.Length - 1)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _movementSpeed * Time.deltaTime);
    }
}