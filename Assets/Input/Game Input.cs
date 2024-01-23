//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/Game Input.inputactions
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

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Game Input"",
    ""maps"": [
        {
            ""name"": ""freeroam"",
            ""id"": ""b7f2a4d7-86c8-45a5-9522-87115c750a86"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""6767bcaa-a277-494b-9306-ecb5ac60b4de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d35d8823-113f-4c92-b55b-29a57f780c1f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""88408d5d-514a-469c-a05f-7f4caf33442f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""19398174-e27a-4e0c-9ce9-45765e46181e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82fb79f5-8d95-425c-8e4e-b83109683529"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c83667b-e558-4f93-b144-f351a028b297"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""df99b2e6-488d-4284-83bb-17053925d790"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default Scheme"",
            ""bindingGroup"": ""Default Scheme"",
            ""devices"": []
        }
    ]
}");
        // freeroam
        m_freeroam = asset.FindActionMap("freeroam", throwIfNotFound: true);
        m_freeroam_Movement = m_freeroam.FindAction("Movement", throwIfNotFound: true);
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
    private readonly InputAction m_freeroam_Movement;
    public struct FreeroamActions
    {
        private @GameInput m_Wrapper;
        public FreeroamActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_freeroam_Movement;
        public InputActionMap Get() { return m_Wrapper.m_freeroam; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeroamActions set) { return set.Get(); }
        public void AddCallbacks(IFreeroamActions instance)
        {
            if (instance == null || m_Wrapper.m_FreeroamActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FreeroamActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IFreeroamActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
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
    private int m_DefaultSchemeSchemeIndex = -1;
    public InputControlScheme DefaultSchemeScheme
    {
        get
        {
            if (m_DefaultSchemeSchemeIndex == -1) m_DefaultSchemeSchemeIndex = asset.FindControlSchemeIndex("Default Scheme");
            return asset.controlSchemes[m_DefaultSchemeSchemeIndex];
        }
    }
    public interface IFreeroamActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
