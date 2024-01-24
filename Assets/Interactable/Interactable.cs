using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Collider collider;
    GameInput input;
    [SerializeField] private InteractTypes interactType = InteractTypes.Item;

    void Interact(InputAction.CallbackContext callbackContext)
    {
        switch (interactType)
        {
            case InteractTypes.Undefined:
                throw new ArgumentOutOfRangeException();
            case InteractTypes.Item:
                Debug.Log("item");
                if (Globals.Instance.cat.HoldItem(transform))
                {
                    collider.enabled = false;
                    OnTriggerExit(null);
                }
                break;
            case InteractTypes.OldMan:
                Debug.Log("man");
                break;
        }
    }

    void Awake()
    {
        input = new GameInput();
    }

    void OnEnable()
    {
        input.freeroam.Enable();
    }
    void OnDisable()
    {
        input.freeroam.Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            Debug.Log("Entered");
            input.freeroam.Interact.performed += Interact;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == null || other.CompareTag("Cat"))
        {
            Debug.Log("Exited");
            input.freeroam.Interact.performed -= Interact;
        }
    }

    public enum InteractTypes
    {
        Undefined,
        Item,
        OldMan,
    }
}
