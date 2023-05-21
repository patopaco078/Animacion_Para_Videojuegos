//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Controles.inputactions
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

public partial class @Controles : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Personaje"",
            ""id"": ""5ecf0b27-bbe1-4413-adfb-2702b02b74c5"",
            ""actions"": [
                {
                    ""name"": ""Movimiento"",
                    ""type"": ""Value"",
                    ""id"": ""2c27d4f7-be1e-4a4c-9794-db3edea52a39"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7f91904f-bbbe-4f7d-8303-93175716c0dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""531b7efb-8d8f-4ab7-a0b7-f287387e759d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AWD"",
                    ""id"": ""df21b7fc-8106-4cce-9aaf-2ca0d91087ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimiento"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b033fee0-befb-4d63-9fa4-a8749bf2fdf3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""23c5ee40-b534-4412-ae81-40d1f892dfef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movimiento"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2735984e-d2d4-420a-b8ae-7a81c38bb0c7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c9eee72-d278-48b0-ad17-ae4ef080ac8e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Personaje
        m_Personaje = asset.FindActionMap("Personaje", throwIfNotFound: true);
        m_Personaje_Movimiento = m_Personaje.FindAction("Movimiento", throwIfNotFound: true);
        m_Personaje_Jump = m_Personaje.FindAction("Jump", throwIfNotFound: true);
        m_Personaje_Run = m_Personaje.FindAction("Run", throwIfNotFound: true);
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

    // Personaje
    private readonly InputActionMap m_Personaje;
    private IPersonajeActions m_PersonajeActionsCallbackInterface;
    private readonly InputAction m_Personaje_Movimiento;
    private readonly InputAction m_Personaje_Jump;
    private readonly InputAction m_Personaje_Run;
    public struct PersonajeActions
    {
        private @Controles m_Wrapper;
        public PersonajeActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movimiento => m_Wrapper.m_Personaje_Movimiento;
        public InputAction @Jump => m_Wrapper.m_Personaje_Jump;
        public InputAction @Run => m_Wrapper.m_Personaje_Run;
        public InputActionMap Get() { return m_Wrapper.m_Personaje; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PersonajeActions set) { return set.Get(); }
        public void SetCallbacks(IPersonajeActions instance)
        {
            if (m_Wrapper.m_PersonajeActionsCallbackInterface != null)
            {
                @Movimiento.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMovimiento;
                @Movimiento.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMovimiento;
                @Movimiento.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnMovimiento;
                @Jump.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PersonajeActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_PersonajeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movimiento.started += instance.OnMovimiento;
                @Movimiento.performed += instance.OnMovimiento;
                @Movimiento.canceled += instance.OnMovimiento;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public PersonajeActions @Personaje => new PersonajeActions(this);
    public interface IPersonajeActions
    {
        void OnMovimiento(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
