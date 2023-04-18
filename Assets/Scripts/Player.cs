using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void Movement(bool _value);
    public event Movement Event_OnPlayerMove;

    GameInput gameInput;

    [SerializeField] 
    byte moveSpeed = 7;
    byte rotationSpeed = 15;

    Vector3 lastInteractDirection;

    [SerializeField] 
    LayerMask counterLayerMask;


    private void Start()
    {
        gameInput = FindObjectOfType<GameInput>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }


    private void HandleInteractions()
    {
        // for input movement
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        lastInteractDirection = moveDirection == Vector3.zero ? lastInteractDirection : moveDirection;

        byte interactDistance = 2;
        if(Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit hit, interactDistance, counterLayerMask))
        {
            if(hit.transform.parent.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }

        }

    }

    private void HandleMovement()
    {
        // for input movement
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); 
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        byte playerHeight = 2;
        float playerRadius = 0.7f;
        float moveDistance = moveSpeed * Time.deltaTime;

        // collision check
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        // animation control
        bool response = inputVector == Vector2.zero ? false : true;
        Event_OnPlayerMove?.Invoke(response);

        // rotation control
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }
}
