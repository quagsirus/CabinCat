using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private InteractTypes interactType = InteractTypes.Item;

    [SerializeField] private Collider collider;
    private GameInput input;
    [SerializeField] private Transform promptTransform;

    private void Interact(InputAction.CallbackContext callbackContext)
    {
        switch (interactType)
        {
            case InteractTypes.Undefined:
                throw new ArgumentOutOfRangeException();
            case InteractTypes.Item:
                Debug.Log("item");
                if (Globals.Instance.Cat.HoldItem(transform.parent))
                {
                    collider.enabled = false;
                    OnTriggerExit(null);
                }

                break;
            case InteractTypes.OldMan:
                Debug.Log("man");
                Globals.Instance.Man.SetText(Globals.Instance.Cat.GiveItem()
                    ? "Thanks for the brick lil feller"
                    : "I have a longing for bricks");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Awake()
    {
        input = new GameInput();
        if (promptTransform != null) promptTransform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        input.freeroam.Enable();
    }

    private void OnDisable()
    {
        input.freeroam.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Cat")) return;
        Debug.Log("Entered");
        input.freeroam.Interact.performed += Interact;
        if (promptTransform != null) promptTransform.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == null || other.CompareTag("Cat"))
        {
            Debug.Log("Exited");
            input.freeroam.Interact.performed -= Interact;
            if (promptTransform != null) promptTransform.gameObject.SetActive(false);
        }
    }

    private enum InteractTypes
    {
        Undefined,
        Item,
        OldMan
    }
}