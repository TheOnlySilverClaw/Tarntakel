using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

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
        transform.position += new Vector3(_movementIntent.x, _movementIntent.y) * _movementSpeed * Time.deltaTime;
    }

    public void Move(CallbackContext context)
    {
        _movementIntent = context.ReadValue<Vector2>();
    }
}
