using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    public Vector3 velocity;
    public LayerMask groundMask;
    public Transform groundCheck;

    [SerializeField] float speed = 12f, groundDistance = 0.4f, jumpHeight = 3f;
    private float gravity  = -9.81f;
    bool isGrounded;


    // Update is called once per frame
    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0f)
            velocity.y = -2f;

        if(Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //create a movement vector relative to the player
        Vector3 move = transform.right*x + transform.forward*z;
        player.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
        
    }
}
