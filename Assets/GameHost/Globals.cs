using UnityEngine;


public delegate void Notify();
public sealed class Globals
{
    public Camera ActiveCamera;
    public Cat Cat;
    public Man Man;
    public event Notify TelescopeActivate;
    public event Notify TelescopeDeactivate;
    public void InteractedWithTelescope()
    {
        TelescopeActivate?.Invoke();
    }

    public void UninteractedWithTelescope()
    {
        TelescopeDeactivate?.Invoke();
    }

    public static Globals Instance => Nested.Instance;

    private class Nested
    {
        public static Nested Instance1 { get; } = new();
        internal static readonly Globals Instance = new();
    }
}