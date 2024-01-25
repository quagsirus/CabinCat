using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameInput _input;
    private Vector2 _lookDelta;
    private Rigidbody _rigidbody;
    private Transform _orbit;

    private const int LookSpeed = 100;

    private void Awake()
    {
        _input = new GameInput();
        _rigidbody = GetComponent<Rigidbody>();
        _orbit = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        _lookDelta += LookSpeed * Time.deltaTime * _input.freeroam.Look.ReadValue<Vector2>();

        var orbitTarget = new Vector3(transform.position.x, transform.parent.position.y, transform.position.z);
        _orbit.LookAt(orbitTarget);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(0, _lookDelta.x, 0, ForceMode.Acceleration);
        _rigidbody.AddForce(0, _lookDelta.y, 0, ForceMode.Acceleration);

        Globals.Instance.Cat.CameraRotation = transform.rotation;
        _lookDelta = Vector2.zero;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _input.freeroam.Enable();
        Globals.Instance.ActiveCamera = GetComponentInChildren<Camera>();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        _input.freeroam.Enable();
        Globals.Instance.ActiveCamera = null;
    }
}