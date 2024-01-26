using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    [SerializeField] private InteractTypes interactType = InteractTypes.Item;
    public Cutscenes memoryToShow = Cutscenes.Undefined;
    [SerializeField] private Collider collider;
    [SerializeField] private Transform promptTransform;
    [SerializeField] private AudioSource audioSource;

    private void Interact(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(Globals.Instance.SFXVolume);
        Debug.Log(Globals.Instance.MusicVolume);
        switch (interactType)
        {
            case InteractTypes.Undefined:
                throw new ArgumentOutOfRangeException();
            case InteractTypes.Item:
                Debug.Log("INFO: Cat Interacted With Item");
                if (Globals.Instance.Cat.HoldItem(transform.parent))
                {
                    collider.enabled = false;
                    transform.parent.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    OnTriggerExit(null);
                    audioSource.volume = Globals.Instance.SFXVolume;
                    audioSource.Play();
                }
                break;
            case InteractTypes.OldMan:
                Debug.Log("INFO: Cat Interacted With Man");
                Globals.Instance.Man.SetText(Globals.Instance.Cat.GiveItem()
                    ? "Thanks for the brick lil feller"
                    : "I have a longing for bricks");
                break;
            case InteractTypes.Telescope:
                Debug.Log("INFO: Cat Interacted With Telescope");
                Globals.Instance.InteractedWithTelescope();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void TelescopeActivated()
    {
        Debug.Log("TelescopeActivated");
    }

    private void Awake()
    {
        if (promptTransform != null) promptTransform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (interactType == InteractTypes.Telescope) Globals.Instance.TelescopeActivate += TelescopeActivated;
    }

    private void OnDisable()
    {
         if (interactType == InteractTypes.Telescope) Globals.Instance.TelescopeActivate -= TelescopeActivated;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdfdgh" + other.name);
        if (!other.CompareTag("Cat")) return;
        Debug.Log("INFO: Entered Trigger Zone Of " + transform.parent.gameObject.name);
        Globals.Instance.Cat.Input.freeroam.Interact.performed += Interact;
        if (promptTransform != null) promptTransform.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == null || other.CompareTag("Cat"))
        {
            Debug.Log("INFO: Entered Trigger Zone Of " + transform.parent.gameObject.name);
            Globals.Instance.Cat.Input.freeroam.Interact.performed -= Interact;
            if (promptTransform != null) promptTransform.gameObject.SetActive(false);
        }
    }

    private enum InteractTypes
    {
        Undefined,
        Item,
        OldMan,
        Telescope
    }
}