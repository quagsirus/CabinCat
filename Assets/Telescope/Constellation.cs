using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    [SerializeField] private Cutscenes cutscene = Cutscenes.Undefined;
    
    public void Clicked()
    {
        Debug.Log("aaaaa");
        Globals.Instance.MemoryManager.DisplayMemory(cutscene);
    }

    
}

