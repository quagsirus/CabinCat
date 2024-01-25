using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
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
        Show();
        Hide();
    }

    private void Awake()
    {
        Globals.Instance.Cat.Input.telescope.Interact.performed += HideOnInteract;
    }

    void Show()
    {
        nightSky.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Globals.Instance.Cat.Input.freeroam.Disable();
        Globals.Instance.Cat.Input.telescope.Enable();
    }

    void Hide()
    {
        nightSky.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Globals.Instance.Cat.Input.freeroam.Enable();
        Globals.Instance.Cat.Input.telescope.Disable();
    }



    void HideOnInteract(InputAction.CallbackContext _)
    {
        Hide();
    }
}
