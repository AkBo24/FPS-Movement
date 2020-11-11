using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    [SerializeField] float speed = 12f;

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse Y");

        //create a movement vector relative to the player
        Vector3 move = transform.right*x + transform.forward*z;

        player.Move(move * speed * Time.deltaTime);
    }
}
