using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float rotateAmount;
    [SerializeField] private float rotateSpeed = 1f;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    public void Cancel()
    {
        StopCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            if (rotateAmount >= 360f) rotateAmount = 0f;
            rotateAmount += rotateSpeed;
            transform.rotation = Quaternion.Euler(0, rotateAmount, 0);
            yield return null;
        }
    }
}
