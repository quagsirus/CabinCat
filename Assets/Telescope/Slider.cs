using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private ValueToChange valueToChange;

    public void OnValueChanged(float newValue)
    {
        if (valueToChange == ValueToChange.Music) Globals.Instance.MusicVolume = newValue;
        else if (valueToChange == ValueToChange.SFX) Globals.Instance.SFXVolume = newValue;
    }
    private enum ValueToChange
    {
        Music,
        SFX
    }
}
