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
        // Creating a new Vector3 as such will create a movement vector relative to the direciton the gameObject is currently facing
        // Time.deltaTime: ensures calculations are independent of frame rate (movement is consistent across diff frame rates)
        Vector3 move = transform.right * moveAxis.x + transform.forward * moveAxis.y;
        _cc.Move(move * movementSpeed * Time.deltaTime);

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
