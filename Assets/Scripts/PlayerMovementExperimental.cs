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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float movementSpeed, gravity_accel;
    [SerializeField] private float groundDist = 1f, jumpHeight = 3f;

    private Vector3 velocity;
    private Vector2 moveAxis;
    private bool isGrounded, jumping;

    void Update() {

        /* Character Movement */

        // Moving the character through a character controller
        // Creating a new Vector3 as such will create a movement vector relative to the direciton the gameObject is currently facing
        // Time.deltaTime: ensures calculations are independent of frame rate (movement is consistent across diff frame rates)
        Vector3 move = transform.right * moveAxis.x + transform.forward * moveAxis.y;
        _cc.Move(move * movementSpeed * Time.deltaTime);

        isGrounded = (Physics.CheckSphere(groundCheck.position, groundDist, groundMask));

        //when player is on ground apply constant velocity of -2f
        if(isGrounded && velocity.y < 0f)
            velocity.y = -2f;

        if(isGrounded && jumping) 
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity_accel);
            // Debug.Log((jumpHeight * 2f * gravity_accel));

        /* Moving the character down for gravity*/
        // v = v_0 + a*T -> kinematics formula
        velocity.y -= gravity_accel * Time.deltaTime;
        _cc.Move(velocity * Time.deltaTime);


        /* Character Jumping */
        // Debug.Log(jumping);


        jumping = false;
    }   

    private void OnEnable() {
        _input = new InputMaster();
        _input.Player.Move.performed += HandleMovement;
        _input.Player.Move.Enable();

        _input.Player.Jump.performed += HandleMobility;
        _input.Player.Jump.Enable();
    }

    private void HandleMovement(InputAction.CallbackContext context) {
        moveAxis = context.ReadValue<Vector2>();
    }

    private void HandleMobility(InputAction.CallbackContext context) {
        jumping = _input.Player.Jump.triggered;

        // Debug.Log(_input.Player.Jump.triggered);
    }

    private void OnDisable() {
        _input.Player.Move.performed -= HandleMovement;
        _input.Player.Move.Disable();

        _input.Player.Jump.performed -= HandleMobility;
        _input.Player.Jump.Disable();
    }

}
