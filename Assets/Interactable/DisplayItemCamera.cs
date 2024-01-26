using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;


    private void Start()
    {
        Globals.Instance.CutsceneStart += SwapCameraToCutscene;
        Globals.Instance.CutsceneStop += SwapCameraToFreeroam;

    }

    private void SwapCameraToCutscene()
    {
        Globals.Instance.ActiveCamera.enabled = false;
        _camera.enabled = true;
    }

    private void SwapCameraToFreeroam()
    {
        _camera.enabled = false;
        Globals.Instance.ActiveCamera.enabled = true;
    }
}
