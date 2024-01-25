using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TelescopeImages : MonoBehaviour 
{
    [SerializeField] private GameObject nightSky;
    void Start()
    {
        Globals.Instance.TelescopeDeactivate += Hide;
        Globals.Instance.TelescopeActivate += Show;
    }

    private void Awake()
    {
        Globals.Instance.Input.freeroam.Interact.performed += HideOnInteract;
    }

    void Show()
    {
        nightSky.SetActive(true);
        Globals.Instance.Input.freeroam.Disable();
        Globals.Instance.Input.telescope.Enable();
    }

    void Hide()
    {
        nightSky.SetActive(false);
        Globals.Instance.Input.freeroam.Enable();
        Globals.Instance.Input.telescope.Disable();
    }

    void HideOnInteract(InputAction.CallbackContext _)
    {
        Hide();
    }
}
