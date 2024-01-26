using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PawsMenu : MonoBehaviour
{
    [SerializeField] private GameObject pawsMenu;
    bool paused = false;
    private ControlMaps controlToReturnTo;
    private bool hasCursorBeenUnlocked;
    private void Start()
    {
        pawsMenu.SetActive(false);
        Globals.Instance.Cat.Input.freeroam.Escape.performed += Activated;
        Globals.Instance.Cat.Input.telescope.Escape.performed += Activated;
        Globals.Instance.Cat.Input.memory.Escape.performed += Activated;
        Globals.Instance.Cat.Input.pause.Escape.performed += Activated;
    }

    private void Activated(InputAction.CallbackContext _)
    {
        if (paused) UnPause();
        else Pause();
    }

    private void Pause()
    {
        paused = true;
        if (Globals.Instance.Cat.Input.freeroam.enabled) {
            Globals.Instance.Cat.Input.freeroam.Disable();
            controlToReturnTo = ControlMaps.Freeroam;
        }
        if (Globals.Instance.Cat.Input.telescope.enabled) {
            Globals.Instance.Cat.Input.telescope.Disable();
            controlToReturnTo = ControlMaps.Telescope;
        }
        if (Globals.Instance.Cat.Input.memory.enabled) {
            Globals.Instance.Cat.Input.memory.Disable();
            controlToReturnTo = ControlMaps.Memory;
        }
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            hasCursorBeenUnlocked = true;
        }
        Globals.Instance.Cat.Input.pause.Enable();
        pawsMenu.SetActive(true);
    }

    private void UnPause()
    {
        
        if (controlToReturnTo == ControlMaps.Freeroam)
        {
            Globals.Instance.Cat.Input.freeroam.Enable();
        }
        if (controlToReturnTo == ControlMaps.Telescope)
        {
            Globals.Instance.Cat.Input.telescope.Enable();
        }
        if (controlToReturnTo == ControlMaps.Memory)
        {
            Globals.Instance.Cat.Input.memory.Enable();
        }
        if (hasCursorBeenUnlocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        hasCursorBeenUnlocked = false;
        pawsMenu.SetActive(false);
        paused = false;
    }

    private enum ControlMaps
    {
        Freeroam,
        Telescope,
        Memory
    }
}
