using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject cutscenePrompt;


    private void Start()
    {
        if (cutscenePrompt != null) cutscenePrompt.SetActive(false);  
        Globals.Instance.CutsceneStart += SwapCameraToCutscene;
        Globals.Instance.CutsceneStop += SwapCameraToFreeroam;
        _camera = transform.GetComponent<Camera>();
        _camera.enabled = false;
    }

    private void OnEnable()
    {
        Globals.Instance.CutsceneStart += SwapCameraToCutscene;
        Globals.Instance.CutsceneStop += SwapCameraToFreeroam;
        
    }

     private void OnDisable()
    {
        Globals.Instance.CutsceneStart -= SwapCameraToCutscene;
        Globals.Instance.CutsceneStop -= SwapCameraToFreeroam;
    }

     private void OnDestroy()
    {
        Globals.Instance.CutsceneStart -= SwapCameraToCutscene;
        Globals.Instance.CutsceneStop -= SwapCameraToFreeroam;
        
    }

    private void SwapCameraToCutscene()
    {
        //_camera = GameObject.Find("Camera").GetComponent<Camera>();
        if (_camera != null){
            _camera.enabled = true;
            Globals.Instance.ActiveCamera.enabled = false;
        }
        if (cutscenePrompt != null)cutscenePrompt.SetActive(true);
    }

    private void SwapCameraToFreeroam()
    {
        // _camera = GameObject.Find("Camera").GetComponent<Camera>();
        if (_camera != null){
            _camera.enabled = false;
            Globals.Instance.ActiveCamera.enabled = true;
        }
        if (cutscenePrompt != null)cutscenePrompt.SetActive(false);
    }
}
