using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class Globals
{
    public Cat cat;
    public static Globals Instance => Nested.Instance;

    private class Nested
    {
        static Nested()
        {
        }

        internal static readonly Globals Instance = new();
    }
}
