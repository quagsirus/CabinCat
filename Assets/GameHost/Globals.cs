using UnityEngine;

public sealed class Globals
{
    public Camera ActiveCamera;
    public Cat Cat;
    public Man Man;

    public static Globals Instance => Nested.Instance;

    private class Nested
    {
        public static Nested Instance1 { get; } = new();
        internal static readonly Globals Instance = new();
    }
}