using NUnit.Framework.Constraints;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CatMovement : MonoBehaviour
{
    [SerializeField] private int jumpHeight = 10;
    [SerializeField] private int lookSpeed = 10;
    [SerializeField] private int moveSpeed = 5000;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool canJump = true;
    [SerializeField] private Collider groundCollider;

    private Vector3 _movementDelta;
    private Controls _input;

    public Quaternion CameraRotation;
    private void Awake()
    {
        _input = new Controls();
        _input.freeroam.jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext _)
    {
        if (Physics.BoxCast(transform.position + new Vector3(0, -0.2f, 0.15f), new Vector3(0.9f, 0.3f, 3), -transform.up,
                Quaternion.identity, float.MaxValue)) return;
       
        //if (!canJump) return;
        
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        canJump = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + new Vector3(0, -0.2f, 0.15f), new Vector3(0.9f, 0.3f, 3)/2);
    }

    private void Land()
    {
        canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Land();
    }

    private void OnEnable()
    {
        _input.freeroam.Enable();
    }

    private void OnDisable()
    {
        _input.freeroam.Disable();
    }

    private void FixedUpdate()
    {
        if (_movementDelta == Vector3.zero) return;
        rb.AddForce(moveSpeed * _movementDelta);
        Quaternion catFaceQuaternion = Quaternion.LookRotation(_movementDelta) * Quaternion.Euler(0, -0, 0);
        ;
        rb.rotation = Quaternion.Lerp(transform.rotation, catFaceQuaternion, Time.fixedDeltaTime * 10);
        _movementDelta = Vector3.zero;
    }

    private void Update()
    {
        CameraRotation = Camera.main.GetComponent<Transform>().localRotation;
        Vector2 movementInput = _input.freeroam.move.ReadValue<Vector2>();


        _movementDelta += Time.deltaTime * movementInput.y * (CameraRotation * Vector3.forward) +
                        Time.deltaTime * movementInput.x * (CameraRotation * Vector3.right);

    }
    void Start()
    {

    }
}
