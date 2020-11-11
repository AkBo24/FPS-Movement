using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    [SerializeField] float speed = 12f;

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //create a movement vector relative to the player
        Vector3 move = transform.right*x + transform.forward*z;

        player.Move(move * speed * Time.deltaTime);
    }
}
