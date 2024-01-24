using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    void Start()
    {
        Globals.Instance.cam = this;
    }
}
