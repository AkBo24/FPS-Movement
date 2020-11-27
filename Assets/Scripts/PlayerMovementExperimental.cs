using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementExperimental : MonoBehaviour
{

    /*
        Notes: Make sure the input for movement is set to Pass through
    */

    //Experimental Input
    [SerializeField] private InputMaster _input;
    [SerializeField] private CharacterController _cc;

    [SerializeField] private float movementSpeed, velocity = 9.81f;
    private Vector2 moveAxis;

    void Update() {

        // Moving the character through a character controller
        // Time.deltaTime: ensures calculations are independent of frame rate (movement is consistent across diff frame rates)
        Vector3 move = new Vector3(moveAxis.x, 0, moveAxis.y)  * movementSpeed * Time.deltaTime;
        _cc.Move(move);

    }   

    private void HandleMovement(InputAction.CallbackContext context) {
        moveAxis = context.ReadValue<Vector2>();
    }

    private void OnEnable() {
        _input = new InputMaster();
        _input.Player.Move.performed += HandleMovement;
        _input.Player.Move.Enable();
    }

    private void OnDisable() {
        _input.Player.Move.performed -= HandleMovement;
        _input.Player.Move.Disable();
    }

}
