using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private float _speed = 5f;
    private bool _isAbleToMove = false;

    private void FixedUpdate()
    {
        if (_isAbleToMove)
        {
            transform.position += transform.forward.normalized * _speed * Time.fixedDeltaTime;
        }
    }

    private void OnDisable()
    {
        EndMovement();
    }

    public void StartMovement(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
        _isAbleToMove = true;
    }

    public void EndMovement()
    {
        _isAbleToMove = false;
    }
}