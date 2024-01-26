using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject cutscenePrompt;


    private void Awake()
    {
        Globals.Instance.CutsceneStart += SwapCameraToCutscene;
        Globals.Instance.CutsceneStop += SwapCameraToFreeroam;
        cutscenePrompt.SetActive(false);
    }

    private void SwapCameraToCutscene()
    {
        Globals.Instance.ActiveCamera.enabled = false;
        transform.GetComponent<Camera>().enabled = true;
        cutscenePrompt.SetActive(true);
        
    }

    private void SwapCameraToFreeroam()
    {
        transform.GetComponent<Camera>().enabled = false;
        Globals.Instance.ActiveCamera.enabled = true;
        cutscenePrompt.SetActive(false);
    }
}
