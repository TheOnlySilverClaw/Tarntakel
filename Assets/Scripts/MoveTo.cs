using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetPosition;
    [SerializeField]
    private float _movementSpeed = 5f;
    private bool _isMoving = false;
    private Vector3 _startPosition;

    public UnityEvent OnMovementDone;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void StartMoving()
    {
        _isMoving = true;
    }

    private void Update()
    {
        if (!_isMoving)
        {
            return;
        }

        Vector3 direction = _targetPosition - _startPosition;
        transform.position += direction.normalized * _movementSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
        {
            OnMovementDone?.Invoke();
            enabled = false;
        }
    }
}
