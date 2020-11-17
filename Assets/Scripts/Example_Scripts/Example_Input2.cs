using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input2 : MonoBehaviour
{

    InputMaster playerInput;
    [SerializeField] CharacterController movement;
    [SerializeField] private float speed;

    void Awake() {
        // fireAction.performed += OnFire;
        // lookAction.performed += OnLook;

        // gameplayActions["fire"].performed += OnFire;

        playerInput = new InputMaster();
        playerInput.Enable();
    }

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
        var moveDirection = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 motion = (moveDirection.x * transform.right + moveDirection.y * transform.forward)* speed * Time.deltaTime;
        movement.Move(motion);

    }
    void OnEnable() {
        // fireAction.Enable();
        // lookAction.Enable();

        // gameplayActions.Enable();
    }

    void OnDisable() {
        // fireAction.Disable();
        // lookAction.Disable();

        // gameplayActions.Disable();
        playerInput.Disable();
    }
}
