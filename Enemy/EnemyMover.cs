using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _minCurrentSpeed;
    [SerializeField] private float _maxCurrentSpeed;
    [SerializeField] private float _currentSpeed;

    [SerializeField] private float _minPatrolDistance;
    [SerializeField] private float _maxPatrolDistance;
    [SerializeField] private float _currentPatrolDistance;

    private Vector3 _startPosition;
    private int _direction;

    private void Start()
    {
        _startPosition = transform.position;
        _direction = 1;
    }

    private void OnValidate()
    {
        Validator.Validate(ref _currentSpeed, _minCurrentSpeed, _maxCurrentSpeed);
        Validator.Validate(ref _currentPatrolDistance, _minPatrolDistance, _maxPatrolDistance);
    }

    public void Move()
    {
        transform.Translate(Vector2.right * _currentSpeed * _direction * Time.deltaTime);
    }

    public void MoveOnTarget(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _currentSpeed * Time.deltaTime);
    }

    public void TryChangeDirection()
    {
        if (Mathf.Abs(transform.position.x - _startPosition.x) >= _currentPatrolDistance)
        {
            _direction *= -1;
            transform.localScale = new Vector3(_direction, 1, 1);
        }            
    }
}