using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Constellation : MonoBehaviour
{
    [SerializeField] private Cutscenes cutscene = Cutscenes.Undefined;
    [SerializeField] private RawImage image;
    [SerializeField] private Texture unlockedImage;
    [SerializeField] bool locked = true;

    public void Clicked()
    {
        if (!locked) Globals.Instance.MemoryManager.DisplayMemory(cutscene);
    }

    public void Unlock()
    {
        image.texture = unlockedImage;
        locked = false;
    }
}

