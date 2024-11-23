using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    private bool facingLeft;

    /// <summary>
    /// Movement intent is already normalized
    /// </summary>
    private Vector2 _movementIntent;

    void Update()
    {
        bool isMoving = _movementIntent.sqrMagnitude > 0.1f;
        _animator.SetBool("isMoving", isMoving);
        //transform.position += new Vector3(_movementIntent.x, _movementIntent.y) * _movementSpeed * Time.deltaTime;
        _rigidbody.velocity = _movementIntent * _movementSpeed;
        orientation();
    }

    public void Panic(GameObject source)
    {
        Vector3 direction = transform.position - source.transform.position;

        Vector2 force = new Vector2(
            direction.x * Random.value * 6000,
            direction.y * Random.value * 3000
        );
        _rigidbody.AddForce(force);
    }

    public void Move(CallbackContext context)
    {
        _movementIntent = context.ReadValue<Vector2>();
    }

    private void orientation()
    {
        Vector3 scale = transform.localScale;
        if(!facingLeft && _movementIntent.x < 0)
        {
            scale.x *= -1;
            facingLeft = true;}
        if(facingLeft && _movementIntent.x > 0)
        {
            scale.x *= -1;
            facingLeft = false;}
        transform.localScale = scale;
    }
}
