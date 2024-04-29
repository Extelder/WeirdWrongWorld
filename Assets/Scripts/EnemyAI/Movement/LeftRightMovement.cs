using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _movementSpeed;

    [SerializeField] private SpriteRenderer _spriteRenderer;

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
        if(Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) <= 1)
        {
            //Debug.Log("ำ๑๋๎โ่ๅ ยÛฯฮหอ฿ลาลาลาลาลาลาลาาลาลาลลา");
            if (_currentWaypoint == _waypoints.Length -1)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _movementSpeed * Time.deltaTime);

        Flip();
    }

    private void Flip()
    {
        if (_waypoints[_currentWaypoint].position.x > transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
}
