using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;


    private void Update()
    {
        if (_camera != null) transform.LookAt(_camera.transform);
        else if (Globals.Instance.ActiveCamera!= null)
        {
            transform.LookAt(Globals.Instance.ActiveCamera.transform.position);
        }
    }
}