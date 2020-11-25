// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerCamera : MonoBehaviour
// {

//     [SerializeField] MovementMaster.MovementMaster movementMaster;
//     [SerializeField] float mouseSens = 100f, xRotation = 0;

//     public Transform playerTransform;

//     private void Awake() {
//         movementMaster = new MovementMaster.MovementMaster();
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         //Keeps cursor on the camera
//         Cursor.lockState = CursorLockMode.Locked;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Debug.Log(movementMaster.Player.Look.ReadValue<Vector2>());

//         float mouseX = movementMaster.Player.Look.ReadValue<Vector2>().x * Time.deltaTime;
//         float mouseY = movementMaster.Player.Look.ReadValue<Vector2>().y * Time.deltaTime;

//         xRotation = -mouseY;
//         xRotation = Mathf.Clamp(xRotation, -90, 90f);

//         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//         playerTransform.Rotate(Vector3.up * mouseX);

//     }

//     private void OnEnable() {
//         movementMaster.Enable();
//     }

//     private void OnDisable() {
//         movementMaster.Disable();
//     }
// }
