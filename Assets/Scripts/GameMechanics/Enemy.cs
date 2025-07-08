using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _speed = 5f;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _direction.normalized * _speed + new Vector3(0, _rigidbody.linearVelocity.y, 0);
    }

    public void StartMovement(Vector3 direction)
    {
        _direction = direction;
    }
}