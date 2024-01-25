using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MemoryManager : MonoBehaviour
{
    private bool enableTelescopeControlsOnMemoryEnd = false;
    [SerializeField] private GameObject[] memories;


    void Awake()
    {
        Globals.Instance.Cat.Input.memory.CloseWindow.performed += CloseMemory;
        Globals.Instance.MemoryManager = this;
    }

    void CloseMemory(InputAction.CallbackContext _)
    {
        if (enableTelescopeControlsOnMemoryEnd) Globals.Instance.Cat.Input.telescope.Enable();
        else Globals.Instance.Cat.Input.freeroam.Enable();
        Globals.Instance.Cat.Input.memory.Disable();
    }

    public void DisplayMemory(Cutscenes cutscene)
    {
        GameObject memoryImage = memories[(int)cutscene];
        memoryImage.SetActive(true);
        enableTelescopeControlsOnMemoryEnd = Globals.Instance.Cat.Input.telescope.enabled;
        Globals.Instance.Cat.Input.memory.Enable();
        Globals.Instance.Cat.Input.freeroam.Disable();
        Globals.Instance.Cat.Input.telescope.Disable();
    }
}
public enum Cutscenes
{
    Undefined,
    Box,
    Flower,
    Fish,
    Book,
    Polaroid
}
