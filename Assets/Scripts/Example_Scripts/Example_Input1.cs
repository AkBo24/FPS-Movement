using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{

    InputMaster player;
    [SerializeField] private float speed;

    private void Awake() {
        player = new InputMaster();
    }

    public void Update() {
        Vector2 movement = player.Player.Move.ReadValue<Vector2>();

        Vector3 currPosition = transform.position;
        currPosition.x += movement.x * speed + movement.y * speed * Time.deltaTime;
        currPosition.z += movement.y * speed * Time.deltaTime;
        transform.position = currPosition;
    }

    private void OnEnable() {
        player.Enable();
    }

    private void OnDisable() {
        player.Disable();
    }

}