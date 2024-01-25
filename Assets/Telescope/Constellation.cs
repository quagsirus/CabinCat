using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Constellation : MonoBehaviour
{
    [SerializeField] private Cutscenes cutscene = Cutscenes.Undefined;
    [SerializeField] private Image image;
    [SerializeField] bool locked = true;

    private void Start()
    {
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0.4f);
    }

    public void Clicked()
    {
        if (!locked) Globals.Instance.MemoryManager.DisplayMemory(cutscene);
    }

    public void Unlock()
    {
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0.9f);
        Debug.Log(image.color.a);
        locked = false;
    }
}

