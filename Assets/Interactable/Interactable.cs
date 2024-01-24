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
    [SerializeField] private Transform promptTransform;

    void Interact(InputAction.CallbackContext callbackContext)
    {
        switch (interactType)
        {
            case InteractTypes.Undefined:
                throw new ArgumentOutOfRangeException();
            case InteractTypes.Item:
                Debug.Log("item");
                if (Globals.Instance.cat.HoldItem(transform.parent))
                {
                    collider.enabled = false;
                    OnTriggerExit(null);
                }
                break;
            case InteractTypes.OldMan:
                Debug.Log("man");
                if (Globals.Instance.cat.GiveItem())
                {
                    Debug.Log("woah cool brick bro");
                }
                else Debug.Log("Find me a brick or die");
                break;
        }
    }

    void Awake()
    {
        input = new GameInput();
        if (promptTransform != null) promptTransform.gameObject.SetActive(false);
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
            if (promptTransform != null) promptTransform.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == null || other.CompareTag("Cat"))
        {
            Debug.Log("Exited");
            input.freeroam.Interact.performed -= Interact;
            if (promptTransform != null) promptTransform.gameObject.SetActive(false);
        }
    }

    public enum InteractTypes
    {
        Undefined,
        Item,
        OldMan,
    }
}
