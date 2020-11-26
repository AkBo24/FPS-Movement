using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    private InputMaster _input;

    [SerializeField] float mouseSens = 100f, xRotation = 0;

    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Keeps cursor on the camera
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {

    }

    private void HandleCamera(InputAction.CallbackContext context) {
        Debug.Log(context.ReadValue<Vector2>());
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
