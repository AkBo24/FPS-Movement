using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] float mouseSens = 100f, xRotation = 0;
    [SerializeField] private Transform playerTransform;

    private InputMaster _input;
    private Vector2 _cameraCoords;

    void Start() {
        //Keeps cursor on the camera
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        float mouseY = _cameraCoords.y;
        float mouseX = _cameraCoords.x;

        /* Rotation for looking up and down */
        //make sure the input action for movement has "Invert Vector2" proccess and "Input Y" checked
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);        
    }

    private void HandleCamera(InputAction.CallbackContext context) {
        // Debug.Log(context.ReadValue<Vector2>());
        _cameraCoords = context.ReadValue<Vector2>();
    }

    private void OnEnable() {
        _input = new InputMaster();
        _input.Player.Look.performed += HandleCamera;
        _input.Enable();
    }

    private void OnDisable() {
        _input.Player.Look.performed -= HandleCamera;
        _input.Disable();
    }
}
