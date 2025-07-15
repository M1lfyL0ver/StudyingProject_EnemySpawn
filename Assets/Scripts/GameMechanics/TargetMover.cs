using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetMover : MonoBehaviour
{
    [SerializeField] private float _endPositionX;
    [SerializeField] private float _endPositionZ;
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _currentTargetPosition;
    private Vector3 _direction;
    private Vector3 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _endPosition = new Vector3(_endPositionX, 0, _endPositionZ);
        _currentTargetPosition = _endPosition;
    }

    void FixedUpdate()
    {
        if (IsEnoughClose(transform.position, _currentTargetPosition, _arrivalThreshold))
        {
            ChangeTargetPosition();
        }

        _direction = _currentTargetPosition - transform.position;
        _velocity = _direction.normalized * _speed;
        _velocity.y = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = _velocity;
    }

    private void ChangeTargetPosition()
    {
        _currentTargetPosition = (_currentTargetPosition == _endPosition) ? _startPosition : _endPosition;
    }

    private float SqrDistance(Vector3 start, Vector3 end)
    {
        start.y = 0;
        end.y = 0;

        return (end - start).sqrMagnitude;
    }

    private bool IsEnoughClose(Vector3 start, Vector3 end, float distance)
    {
        return SqrDistance(start, end) <= distance * distance;
    }
}