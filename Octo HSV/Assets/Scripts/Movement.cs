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
    private bool facingLeft;

    /// <summary>
    /// Movement intent is already normalized
    /// </summary>
    private Vector2 _movementIntent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        bool isMoving = _movementIntent.sqrMagnitude > 0.1f;
        _animator.SetBool("isMoving", isMoving);
        transform.position += new Vector3(_movementIntent.x, _movementIntent.y) * _movementSpeed * Time.deltaTime;
        orientation();
    }

    public void Move(CallbackContext context)
    {
        _movementIntent = context.ReadValue<Vector2>();
    }

    private void orientation(){
        Vector3 scale = transform.localScale;
        if(!facingLeft && _movementIntent.x < 0){
            scale.x *= -1;
            facingLeft = true;}
        if(facingLeft && _movementIntent.x > 0){
            scale.x *= -1;
            facingLeft = false;}
        transform.localScale = scale;
    }
}
