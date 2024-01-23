using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cat : MonoBehaviour
{
    GameInput input;
    [SerializeField] Rigidbody rb;
    [SerializeField] int moveSpeed = 10;
    Vector3 moveLocation;

    void Awake()
    {
        input = new();
    }
    void OnEnable()
    {
        input.freeroam.Enable();
    }
    void OnDisable()
    {
        input.freeroam.Disable();
    }
    void FixedUpdate()
    {
        rb.MovePosition(moveSpeed * Time.fixedDeltaTime * moveLocation + rb.position);
    }

    void Update()
    {
        moveLocation = (input.freeroam.Movement.ReadValue<Vector2>().x * -transform.forward) +
            (input.freeroam.Movement.ReadValue<Vector2>().y * transform.right);
    }
}
