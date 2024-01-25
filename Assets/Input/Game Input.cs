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
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0d47385d-d62d-4d3e-96a9-27bb8c2c8223"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""55e4d371-3dd6-4df8-a2cb-1748f787cdef"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""559aaf14-b333-4736-a06f-8524fd964901"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
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
                },
                {
                    ""name"": """",
                    ""id"": ""1457048d-a67f-4a68-b4b5-33bae43c3839"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c4da6a1-884d-4a82-a196-d8588030f363"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f586806d-2cca-4563-b749-269e11f4f18e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed83e387-4671-45d6-9a62-6f6fbf39e511"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6c79ee3-14e7-4bd9-ad34-8cadc7788a3c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03f31b37-1433-495a-8803-7ed840c51b40"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a5217dd-8530-4bd6-99da-1edda81c8a04"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""telescope"",
            ""id"": ""4b37a9f3-a6fb-44ea-b1fe-321d5a54a65c"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d53829ab-6271-4618-bc23-020660ee6be6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61a4d7d8-9b87-4f6d-8ea5-285308e50118"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d1b9f27-2e9b-47da-97be-1bcce031b954"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""memory"",
            ""id"": ""8a8b7e8f-4390-4994-b4e8-343efe8c3dda"",
            ""actions"": [
                {
                    ""name"": ""CloseWindow"",
                    ""type"": ""Button"",
                    ""id"": ""b7a9c4c9-7bd9-494d-96fb-3276fdab0794"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""debd8fe9-4175-473e-8a17-0579908562d9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""CloseWindow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4198636a-716a-4cde-81cf-7ba60501bfc9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""CloseWindow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd981b59-51dd-4902-8ff5-e10350075cde"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default Scheme"",
                    ""action"": ""CloseWindow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        m_freeroam_Jump = m_freeroam.FindAction("Jump", throwIfNotFound: true);
        m_freeroam_Look = m_freeroam.FindAction("Look", throwIfNotFound: true);
        m_freeroam_Interact = m_freeroam.FindAction("Interact", throwIfNotFound: true);
        // telescope
        m_telescope = asset.FindActionMap("telescope", throwIfNotFound: true);
        m_telescope_Interact = m_telescope.FindAction("Interact", throwIfNotFound: true);
        // memory
        m_memory = asset.FindActionMap("memory", throwIfNotFound: true);
        m_memory_CloseWindow = m_memory.FindAction("CloseWindow", throwIfNotFound: true);
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
    private readonly InputAction m_freeroam_Jump;
    private readonly InputAction m_freeroam_Look;
    private readonly InputAction m_freeroam_Interact;
    public struct FreeroamActions
    {
        private @GameInput m_Wrapper;
        public FreeroamActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_freeroam_Movement;
        public InputAction @Jump => m_Wrapper.m_freeroam_Jump;
        public InputAction @Look => m_Wrapper.m_freeroam_Look;
        public InputAction @Interact => m_Wrapper.m_freeroam_Interact;
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
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IFreeroamActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
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

    // telescope
    private readonly InputActionMap m_telescope;
    private List<ITelescopeActions> m_TelescopeActionsCallbackInterfaces = new List<ITelescopeActions>();
    private readonly InputAction m_telescope_Interact;
    public struct TelescopeActions
    {
        private @GameInput m_Wrapper;
        public TelescopeActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_telescope_Interact;
        public InputActionMap Get() { return m_Wrapper.m_telescope; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TelescopeActions set) { return set.Get(); }
        public void AddCallbacks(ITelescopeActions instance)
        {
            if (instance == null || m_Wrapper.m_TelescopeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TelescopeActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(ITelescopeActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(ITelescopeActions instance)
        {
            if (m_Wrapper.m_TelescopeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITelescopeActions instance)
        {
            foreach (var item in m_Wrapper.m_TelescopeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TelescopeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TelescopeActions @telescope => new TelescopeActions(this);

    // memory
    private readonly InputActionMap m_memory;
    private List<IMemoryActions> m_MemoryActionsCallbackInterfaces = new List<IMemoryActions>();
    private readonly InputAction m_memory_CloseWindow;
    public struct MemoryActions
    {
        private @GameInput m_Wrapper;
        public MemoryActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseWindow => m_Wrapper.m_memory_CloseWindow;
        public InputActionMap Get() { return m_Wrapper.m_memory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MemoryActions set) { return set.Get(); }
        public void AddCallbacks(IMemoryActions instance)
        {
            if (instance == null || m_Wrapper.m_MemoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MemoryActionsCallbackInterfaces.Add(instance);
            @CloseWindow.started += instance.OnCloseWindow;
            @CloseWindow.performed += instance.OnCloseWindow;
            @CloseWindow.canceled += instance.OnCloseWindow;
        }

        private void UnregisterCallbacks(IMemoryActions instance)
        {
            @CloseWindow.started -= instance.OnCloseWindow;
            @CloseWindow.performed -= instance.OnCloseWindow;
            @CloseWindow.canceled -= instance.OnCloseWindow;
        }

        public void RemoveCallbacks(IMemoryActions instance)
        {
            if (m_Wrapper.m_MemoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMemoryActions instance)
        {
            foreach (var item in m_Wrapper.m_MemoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MemoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MemoryActions @memory => new MemoryActions(this);
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
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ITelescopeActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IMemoryActions
    {
        void OnCloseWindow(InputAction.CallbackContext context);
    }
}
