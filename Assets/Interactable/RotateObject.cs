using System.Collections;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private readonly float rotateSpeed = 1f;
    private float rotateAmount;

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