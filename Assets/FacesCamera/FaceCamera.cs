using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Globals.Instance.cam.transform.position);
    }
}
