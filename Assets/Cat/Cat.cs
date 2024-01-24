using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cat : MonoBehaviour
{
    GameInput input;
    [SerializeField] Rigidbody rb;
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int jumpHeight = 10;
    [SerializeField] int lookSpeed = 10;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody camRb;
    [SerializeField] Transform mouthPosition;
    [SerializeField] private Transform heldItem;
    Vector3 moveLocation;
    Vector2 inputRotation;
    Quaternion targetCameraRotation;

    void Awake()
    {
        input = new();
        input.freeroam.Jump.performed += Jump;
        
    }

    void Start()
    {
        Globals.Instance.cat = this;
    }

    void Jump(InputAction.CallbackContext _)
    {
        //rb.velocity += (Vector3.up * jumpHeight);
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        input.freeroam.Enable();
    }
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        input.freeroam.Disable();
    }
    void FixedUpdate()
    {
        /*targetAngleY = /* Input based function /
        currentAngleY = Mathf.SmoothDampAngle(currentAngleY, targetAngleY, ref velocityAngleY, dampingParameter, maxAngularVelocity, Time.fixedDeltaTime);
    
        Vector3 rot = rigid.rotation.eulerAngles;
        rot.y = currentAngleY;
        rigid.rotation = Quaternion.Euler(rot);*/


        rb.MovePosition(moveSpeed * Time.fixedDeltaTime * moveLocation + rb.position);
        //camRb.MoveRotation(Quaternion.Euler(0, inputRotation.x + camRb.rotation.y, inputRotation.y + camRb.rotation.z));
        //camRb.AddTorque(lookSpeed * Time.fixedDeltaTime * new Vector3(0, inputRotation.x * camRb.transform.up.y, inputRotation.y * camRb.transform.right.x));
        //camRb.transform.rotation.Set(0f, camRb.transform.rotation.y, camRb.transform.rotation.z, camRb.transform.rotation.w);
        
        //camRb.angularVelocity += (lookSpeed * Time.fixedDeltaTime * new Vector3(0, inputRotation.x, inputRotation.y));
        var direction = camRb.transform.up * inputRotation.x + camRb.transform.right * inputRotation.y;
        //camRb.MoveRotation(camRb.rotation * Quaternion.LookRotation(direction));
        inputRotation = Vector2.zero;
    }

    void Update()
    {
        moveLocation = (input.freeroam.Movement.ReadValue<Vector2>().x * -transform.forward) +
            (input.freeroam.Movement.ReadValue<Vector2>().y * transform.right);
        //inputRotation += (input.freeroam.Look.ReadValue<Vector2>());

        //targetCameraRotation *= Quaternion.Euler(0, inputRotation.x, inputRotation.y);
        //camRb.transform.rotation = Quaternion.Slerp(camRb.transform.rotation, targetCameraRotation, Time.deltaTime * 2);
    }

    public bool HoldItem(Transform item)
    {
        if (heldItem != null) return false;
        item.SetParent(mouthPosition);
        item.position = mouthPosition.position;
        heldItem = item;
        return true;
    }

    public bool GiveItem()
    {
        if (heldItem == null) return false;
        Destroy(heldItem.gameObject);
        heldItem = null;
        return true;
    }
}
