using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Globals.Instance.ActiveCamera.transform.position);
    }
}