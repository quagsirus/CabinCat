using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private readonly float rotateSpeed = 1f;
    private float rotateAmount;
    private IEnumerator activeCoroutine;

    private void Start()
    {
        activeCoroutine = Rotate();
        StartCoroutine(activeCoroutine);
    }

    public void Cancel()
    {
        StopCoroutine(activeCoroutine);
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