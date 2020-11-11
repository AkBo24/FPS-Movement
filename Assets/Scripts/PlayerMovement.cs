using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    [SerializeField] float speed = 12f;
    private float gravity  = -9.81f;
    public Vector3 velocity;

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //create a movement vector relative to the player
        Vector3 move = transform.right*x + transform.forward*z;
        player.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
        
    }
}
