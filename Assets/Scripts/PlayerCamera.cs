using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] MovementMaster.MovementMaster movementMaster;

    private void Awake() {
        movementMaster = new MovementMaster.MovementMaster();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Keeps cursor on the camera
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementMaster.Player.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        movementMaster.Enable();
    }

    private void OnDisable() {
        movementMaster.Disable();
    }
}
