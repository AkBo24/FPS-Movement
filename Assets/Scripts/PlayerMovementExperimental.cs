using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementExperimental : MonoBehaviour
{

    //Experimental Input
    [SerializeField] private InputMaster _input;
    [SerializeField] private CharacterController _cc;

    [SerializeField] private float movementSpeed, velocity = 9.81f;
    private Vector2 moveAxis;

    void Update() {

        // Vector3 move = transform.right*x + transform.forward*z;
        Vector3 move = new Vector3(moveAxis.x, 0, moveAxis.y)  * movementSpeed * Time.deltaTime;

        Debug.Log(move);

        _cc.Move(move);

        if(_input.Player.Move.ReadValue<Vector2>() == Vector2.zero)
            moveAxis = Vector2.zero;

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
