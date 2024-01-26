using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameInput _input;
    private Vector2 _lookDelta;
    private Rigidbody _rigidbody;
    private Transform _orbit;

    private const int LookSpeed = 100;

    private const int MinDistance = 1; // Minimum distance from the pivot
    private const int MaxDistance = 5; // Maximum distance from the pivot
    private const int ZoomSpeed = 5; // Speed of zooming

    public LayerMask CollisionLayers;

    private float GetCurrentDistance()
    {
        return Vector3.Distance(transform.parent.position, _orbit.position);
    }

    private void Awake()
    {
        _input = new GameInput();
        _rigidbody = GetComponent<Rigidbody>();
        _orbit = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        _lookDelta += LookSpeed * Time.deltaTime * _input.freeroam.Look.ReadValue<Vector2>();

        var pivotTransform = transform;
        var orbitTarget = new Vector3(pivotTransform.position.x, pivotTransform.parent.position.y, pivotTransform.position.z);
        _orbit.LookAt(orbitTarget);

        if (Physics.Raycast(pivotTransform.parent.position,
                NewOrbitDistance(MaxDistance, pivotTransform.parent.position) - pivotTransform.parent.position,
                out var hit,
                MaxDistance,
                CollisionLayers))
        {
            var newDistance = Mathf.Clamp(hit.distance, MinDistance, MaxDistance);
            _orbit.position = NewOrbitDistance(newDistance, pivotTransform.parent.position);
        }
        else
        {
            _orbit.position = NewOrbitDistance(Mathf.Lerp(GetCurrentDistance(), MaxDistance, ZoomSpeed * Time.deltaTime), pivotTransform.parent.position);
        }
    }

    private Vector3 NewOrbitDistance(float newDistance, Vector3 positionToOrbit)
    {
        var directionToCamera = (_orbit.position - positionToOrbit).normalized;
        return positionToOrbit + directionToCamera * newDistance;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(0, _lookDelta.x, 0, ForceMode.Acceleration);
        _rigidbody.AddForce(0, -_lookDelta.y, 0, ForceMode.Acceleration);

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