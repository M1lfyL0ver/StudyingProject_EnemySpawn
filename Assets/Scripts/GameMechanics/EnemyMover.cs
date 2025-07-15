using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Target _target;
    private Vector3 _direction;
    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (enabled)
        {
            UpdateDirection(_target);
            _velocity = _direction.normalized * _speed;
            _velocity.y = _rigidbody.linearVelocity.y;
            _rigidbody.linearVelocity = _velocity;
        }
    }

    public void SetTarget(Target target) => _target = target;

    private void UpdateDirection(Target target) => _direction = target.transform.position - transform.position;
}