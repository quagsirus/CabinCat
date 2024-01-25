using UnityEngine;
using UnityEngine.InputSystem;

public class Cat : MonoBehaviour
{
    [SerializeField] private int jumpHeight = 10;
    [SerializeField] private int lookSpeed = 10;
    [SerializeField] private int moveSpeed = 30000;
    [SerializeField] private Rigidbody camRb;
    [SerializeField] private Transform heldItem;
    private Vector2 inputRotation;
    [SerializeField] private Transform mouthPosition;
    private Vector3 movementDelta;
    [SerializeField] private Rigidbody rb;
    private Quaternion targetCameraRotation;
    public GameInput Input;

    public Quaternion CameraRotation;

    private void Awake()
    {
        Input = new GameInput();
        Input.freeroam.Jump.performed += Jump;
        Globals.Instance.Cat = this;
    }

    private void Jump(InputAction.CallbackContext _)
    {
        //rb.velocity += (Vector3.up * jumpHeight);
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        Input.freeroam.Enable();
    }

    private void OnDisable()
    {
        Input.freeroam.Disable();
    }

    private void FixedUpdate()
    {
        if (movementDelta == Vector3.zero) return;
        rb.AddForce(moveSpeed * movementDelta);
        var catFaceQuaternion = Quaternion.LookRotation(movementDelta) * Quaternion.Euler(0, -90, 0);;
        rb.rotation = Quaternion.Lerp(transform.rotation, catFaceQuaternion, Time.fixedDeltaTime * 10);
        movementDelta = Vector3.zero;
    }

    private void Update()
    {
        var movementInput = Input.freeroam.Movement.ReadValue<Vector2>();
        

        movementDelta += Time.deltaTime * movementInput.x * (CameraRotation * -Vector3.forward) +
                        Time.deltaTime * movementInput.y * (CameraRotation * Vector3.right);
    }

    public bool HoldItem(Transform item)
    {
        if (heldItem != null) return false;
        item.SetParent(mouthPosition);
        item.position = mouthPosition.position;
        var rotateScript = item.GetComponent<RotateObject>();
        if (rotateScript != null) rotateScript.Cancel();
        heldItem = item;
        return true;
    }

    public bool GiveItem()
    {
        if (heldItem == null) return false;
        var storedMemory = heldItem.GetChild(0).GetComponent<Interactable>().memoryToShow;
        if (storedMemory != Cutscenes.Undefined) Globals.Instance.MemoryManager.DisplayMemory(storedMemory);
        Destroy(heldItem.gameObject);
        heldItem = null;
        return true;
    }
}