using UnityEditor.Experimental.GraphView;
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
    private const float MaxDistance = 2.0f; // Maximum distance from the pivot

    private float AdaptiveMaxDistance(float yOffset)
    {
        return Mathf.Clamp(MinDistance + yOffset * 1f, 0, MaxDistance);
    }

    private const int ZoomSpeed = 5; // Speed of zooming

    public LayerMask CollisionLayers;

    private float GetCurrentDistance()
    {
        return Vector3.Distance(transform.position, _orbit.position);
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

        var orbitTarget = new Vector3(transform.position.x, transform.parent.position.y, transform.position.z);
        _orbit.LookAt(orbitTarget);

        var frameMaxDistance = AdaptiveMaxDistance(transform.position.y - transform.parent.position.y);

        if (Physics.Raycast(transform.position,
                NewOrbitDistance(frameMaxDistance) - transform.position,
                out var hit,
                MaxDistance,
                CollisionLayers))
        {
            var newDistance = Mathf.Clamp(hit.distance, MinDistance, frameMaxDistance);
            _orbit.position = NewOrbitDistance(newDistance);
        }
        else
        {
            _orbit.position = NewOrbitDistance(Mathf.Lerp(GetCurrentDistance(), frameMaxDistance, ZoomSpeed * Time.deltaTime));
        }
    }

    private Vector3 NewOrbitDistance(float newDistance)
    {
        var directionToCamera = (_orbit.position - transform.position).normalized;
        return transform.position + directionToCamera * newDistance;
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