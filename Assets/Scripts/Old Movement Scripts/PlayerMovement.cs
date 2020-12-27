// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public CharacterController player;
//     public Vector3 velocity;
//     public LayerMask groundMask;
//     public Transform groundCheck;

//     [SerializeField] private float speed = 12f, groundDistance = 1f, jumpHeight = 3f;
//     private float gravity  = -9.81f;
//     bool isGrounded;

//     [SerializeField] private float slideHeight, slideDuration, slideSpeed;
//     private float originalHeight;

//     void Start() {
//         originalHeight = player.height;
//     }

//     // Update is called once per frame
//     void Update() {

//         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
//         if(isGrounded && velocity.y < 0f)
//             velocity.y = -2f;

//         if(Input.GetButtonDown("Jump") && isGrounded)
//             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");

//         if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
//             StartCoroutine("Slide");

//         //create a movement vector relative to the player
//         Vector3 move = transform.right*x + transform.forward*z;
//         player.Move(move * speed * Time.deltaTime);

//         velocity.y += gravity * Time.deltaTime;
//         player.Move(velocity * Time.deltaTime);
        
//     }

//     IEnumerator Slide() {

//         float startTime = Time.time;
//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");
//         Vector3 move = transform.right*x + transform.forward*z;

//         while(Time.time < (startTime + slideDuration)) {
//             player.height = slideHeight;
//             player.Move(move * slideSpeed);
//             yield return null;
//         }

//         player.height = originalHeight;
//     }
// }
