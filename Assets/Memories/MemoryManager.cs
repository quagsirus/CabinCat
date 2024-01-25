using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MemoryManager : MonoBehaviour
{
    private bool enableTelescopeControlsOnMemoryEnd = false;
    [SerializeField] private GameObject[] memories;
    private GameObject memoryToClose;


    void Awake()
    {
        Globals.Instance.Cat.Input.memory.CloseWindow.performed += CloseMemory;
        Globals.Instance.MemoryManager = this;
    }

    void CloseMemory(InputAction.CallbackContext _)
    {
        Globals.Instance.Cat.Input.memory.Disable();
        if (enableTelescopeControlsOnMemoryEnd) Globals.Instance.Cat.Input.telescope.Enable();
        else Globals.Instance.Cat.Input.freeroam.Enable();
        memoryToClose.SetActive(false);
    }

    public void DisplayMemory(Cutscenes cutscene)
    {
        GameObject memoryImage = memories[(int)cutscene];
        memoryImage.SetActive(true);
        memoryToClose = memoryImage;
        enableTelescopeControlsOnMemoryEnd = Globals.Instance.Cat.Input.telescope.enabled;
        if (!enableTelescopeControlsOnMemoryEnd)
        {
            memoryImage.GetComponent<MemoryImage>().memoryConstellationButton.Unlock();
        }
        Globals.Instance.Cat.Input.memory.Enable();
        if (Globals.Instance.Cat.Input.freeroam.enabled) Globals.Instance.Cat.Input.freeroam.Disable();
        if (Globals.Instance.Cat.Input.telescope.enabled) Globals.Instance.Cat.Input.telescope.Disable();
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
