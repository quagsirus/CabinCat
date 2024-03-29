//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.0
//     from Assets/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""freeroam"",
            ""id"": ""0df58802-1a79-4890-af28-146ebb15abd0"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""50df78f2-7845-4433-86d3-6cf5a0398375"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""2acb38c3-e9bb-4a4c-9cc6-572208e9ae1a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""df934eb1-e6c9-49d2-8acf-844d35a51b0c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""20db498e-caad-453c-bdae-e1707e6f0401"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a28e92d-e48f-4b86-ba15-2dc32f34e59f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2a7f8b24-8146-48d8-a3ac-9b979f230616"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65e3e525-473a-4b2a-9ab9-c537aa84cb05"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1e08f3a8-cef7-404d-bccb-ea2a8ce5c6af"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // freeroam
        m_freeroam = asset.FindActionMap("freeroam", throwIfNotFound: true);
        m_freeroam_move = m_freeroam.FindAction("move", throwIfNotFound: true);
        m_freeroam_jump = m_freeroam.FindAction("jump", throwIfNotFound: true);
    }

    ~@Controls()
    {
        Debug.Assert(!m_freeroam.enabled, "This will cause a leak and performance issues, Controls.freeroam.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // freeroam
    private readonly InputActionMap m_freeroam;
    private List<IFreeroamActions> m_FreeroamActionsCallbackInterfaces = new List<IFreeroamActions>();
    private readonly InputAction m_freeroam_move;
    private readonly InputAction m_freeroam_jump;
    public struct FreeroamActions
    {
        private @Controls m_Wrapper;
        public FreeroamActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_freeroam_move;
        public InputAction @jump => m_Wrapper.m_freeroam_jump;
        public InputActionMap Get() { return m_Wrapper.m_freeroam; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeroamActions set) { return set.Get(); }
        public void AddCallbacks(IFreeroamActions instance)
        {
            if (instance == null || m_Wrapper.m_FreeroamActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FreeroamActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @jump.started += instance.OnJump;
            @jump.performed += instance.OnJump;
            @jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IFreeroamActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @jump.started -= instance.OnJump;
            @jump.performed -= instance.OnJump;
            @jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IFreeroamActions instance)
        {
            if (m_Wrapper.m_FreeroamActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFreeroamActions instance)
        {
            foreach (var item in m_Wrapper.m_FreeroamActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FreeroamActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FreeroamActions @freeroam => new FreeroamActions(this);
    public interface IFreeroamActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
