using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cat : MonoBehaviour
{
    [SerializeField] private int jumpHeight = 10;
    [SerializeField] private int lookSpeed = 10;
    [SerializeField] private int moveSpeed = 5000;
    [SerializeField] private Rigidbody camRb;
    [SerializeField] private Transform heldItem;
    [SerializeField] private Transform mouthPosition;
    private Vector3 movementDelta;
    [SerializeField] private Rigidbody rb;
    private Quaternion targetCameraRotation;
    private Animator animator;
    public GameInput Input;

    public Quaternion CameraRotation;
    private static int _still;

    private void Awake()
    {
        Input = new GameInput();
        Input.freeroam.Jump.performed += Jump;
        Globals.Instance.Cat = this;

        animator = GetComponent<Animator>();
        _still = Animator.StringToHash("still");
    }

    private void Jump(InputAction.CallbackContext _)
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        animator.Play("rig|Jump");
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
        var catFaceQuaternion = Quaternion.LookRotation(movementDelta) * Quaternion.Euler(0, -0, 0);;
        rb.rotation = Quaternion.Lerp(transform.rotation, catFaceQuaternion, Time.fixedDeltaTime * 10);
        movementDelta = Vector3.zero;
    }

    private void Update()
    {
        var movementInput = Input.freeroam.Movement.ReadValue<Vector2>();
        

        movementDelta += Time.deltaTime * movementInput.x * (CameraRotation * -Vector3.forward) +
                        Time.deltaTime * movementInput.y * (CameraRotation * Vector3.right);

        animator.SetBool(_still, movementDelta == Vector3.zero);
    }

    public bool HoldItem(Transform item, float itemOffset = 0f, float upwardsOffset = 0f, float rotationOffsetX = 0f, float rotationOffsetY = 0f, float rotationOffsetZ = 0f)
    {
        if (heldItem != null) return false;
        item.position = mouthPosition.position;
        item.position += transform.forward * itemOffset; 
        item.position += transform.up * upwardsOffset; 
        item.SetParent(mouthPosition);
        item.rotation = mouthPosition.rotation * Quaternion.Euler(rotationOffsetX, rotationOffsetY, rotationOffsetZ);
        Globals.Instance.ItemCollected();
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
        Globals.Instance.ItemPresented();
        Destroy(heldItem.gameObject);
        heldItem = null;
        return true;
    }
}