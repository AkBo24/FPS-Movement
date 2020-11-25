using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementExperimental : MonoBehaviour
{

    //Experimental Input
    [SerializeField] private InputMaster movement;
    [SerializeField] private CharacterController charController;

    [SerializeField] private float movementSpeed, velocity = 9.81f;
    private Vector2 moveAxis;

    private void OnEnable() {
        movement = new InputMaster();
        movement.Player.Move.performed += HandleMovement;
        movement.Player.Move.Enable();
    }

    void Update() {

        // Vector3 move = transform.right*x + transform.forward*z;
        Vector3 move = new Vector3(moveAxis.x * movementSpeed * Time.deltaTime,
                                   0,
                                   moveAxis.y * movementSpeed * Time.deltaTime );

        charController.Move(move);
        Debug.Log(move);
        move = Vector3.zero;
        
    }   

    private void HandleMovement(InputAction.CallbackContext context)
    {
        // throw new NotImplementedException();

        // Debug.Log(context.ReadValue<Vector2>());
        moveAxis = context.ReadValue<Vector2>();
        // Debug.Log(moveAxis);


    }

    private void OnDisable() {
        movement.Player.Move.performed -= HandleMovement;
        movement.Player.Move.Disable();
    }

}
