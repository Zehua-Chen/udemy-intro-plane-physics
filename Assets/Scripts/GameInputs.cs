// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Airplane"",
            ""id"": ""586795a1-62c4-4765-9229-5c8212e2a62d"",
            ""actions"": [
                {
                    ""name"": ""Pitch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f20afcff-2e0b-4a1a-b032-38cb59bd2268"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3e2f6bc0-77ea-412e-ae26-18af59592a06"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""PassThrough"",
                    ""id"": ""54f1fd35-4c64-4dca-9211-d3945c6c6347"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45734b21-5aed-4c8f-aaa7-bfa0d61e84ec"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flaps"",
                    ""type"": ""PassThrough"",
                    ""id"": ""131be2f9-556d-4172-807b-3446412d68b4"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ac6d94f1-8888-43c8-a33c-3496dd4de4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""a0cd677d-48f9-437a-b8c6-986695e6a827"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b36fe7a2-fd57-4cfd-adfa-f86799483a25"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f0d22efd-269f-4023-a5f6-99f36a0fc42b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""59b76128-0ac2-4cf9-801c-bb979d9f7d72"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Airplane
        m_Airplane = asset.FindActionMap("Airplane", throwIfNotFound: true);
        m_Airplane_Pitch = m_Airplane.FindAction("Pitch", throwIfNotFound: true);
        m_Airplane_Roll = m_Airplane.FindAction("Roll", throwIfNotFound: true);
        m_Airplane_Yaw = m_Airplane.FindAction("Yaw", throwIfNotFound: true);
        m_Airplane_Throttle = m_Airplane.FindAction("Throttle", throwIfNotFound: true);
        m_Airplane_Flaps = m_Airplane.FindAction("Flaps", throwIfNotFound: true);
        m_Airplane_Brake = m_Airplane.FindAction("Brake", throwIfNotFound: true);
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

    // Airplane
    private readonly InputActionMap m_Airplane;
    private IAirplaneActions m_AirplaneActionsCallbackInterface;
    private readonly InputAction m_Airplane_Pitch;
    private readonly InputAction m_Airplane_Roll;
    private readonly InputAction m_Airplane_Yaw;
    private readonly InputAction m_Airplane_Throttle;
    private readonly InputAction m_Airplane_Flaps;
    private readonly InputAction m_Airplane_Brake;
    public struct AirplaneActions
    {
        private @GameInputs m_Wrapper;
        public AirplaneActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pitch => m_Wrapper.m_Airplane_Pitch;
        public InputAction @Roll => m_Wrapper.m_Airplane_Roll;
        public InputAction @Yaw => m_Wrapper.m_Airplane_Yaw;
        public InputAction @Throttle => m_Wrapper.m_Airplane_Throttle;
        public InputAction @Flaps => m_Wrapper.m_Airplane_Flaps;
        public InputAction @Brake => m_Wrapper.m_Airplane_Brake;
        public InputActionMap Get() { return m_Wrapper.m_Airplane; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirplaneActions set) { return set.Get(); }
        public void SetCallbacks(IAirplaneActions instance)
        {
            if (m_Wrapper.m_AirplaneActionsCallbackInterface != null)
            {
                @Pitch.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnPitch;
                @Roll.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnRoll;
                @Yaw.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnYaw;
                @Throttle.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnThrottle;
                @Flaps.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFlaps;
                @Flaps.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFlaps;
                @Flaps.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnFlaps;
                @Brake.started -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_AirplaneActionsCallbackInterface.OnBrake;
            }
            m_Wrapper.m_AirplaneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Flaps.started += instance.OnFlaps;
                @Flaps.performed += instance.OnFlaps;
                @Flaps.canceled += instance.OnFlaps;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
            }
        }
    }
    public AirplaneActions @Airplane => new AirplaneActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IAirplaneActions
    {
        void OnPitch(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnFlaps(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
    }
}
