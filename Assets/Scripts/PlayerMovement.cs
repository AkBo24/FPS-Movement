using UnityEngine;
using UnityEngine.InputSystem;
using MovementMaster;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private MovementMaster.MovementMaster movementMaster;
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float movementSpeed;

    void Awake()
    {
        movementMaster = new MovementMaster.MovementMaster();   
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(movementMaster.Player.Move.ReadValue<Vector2>());

        float x = movementMaster.Player.Move.ReadValue<Vector2>()[0];
        float z = movementMaster.Player.Move.ReadValue<Vector2>()[1];
        Vector3 move = transform.right*x + transform.forward*z;

        playerController.Move(move * movementSpeed * Time.deltaTime);
    }

    private void OnEnable() {
        movementMaster.Enable();
    }

    private void OnDisable() {
        movementMaster.Disable();
    }
}
