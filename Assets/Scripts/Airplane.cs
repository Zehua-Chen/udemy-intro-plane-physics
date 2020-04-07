using UnityEngine;

public class Airplane : MonoBehaviour
{
    GameInputs _inputs = null;

    float _pitch = 0.0f;
    float _roll = 0.0f;
    float _yaw = 0.0f;
    float _throttle = 0.0f;
    float _flaps = 0;
    float _brake;

    private void Awake()
    {
        _inputs = new GameInputs();
        _inputs.Airplane.Pitch.performed += ctx => _pitch = ctx.ReadValue<float>();
        _inputs.Airplane.Roll.performed += ctx => _roll = ctx.ReadValue<float>();
        _inputs.Airplane.Yaw.performed += ctx => _yaw = ctx.ReadValue<float>();
        _inputs.Airplane.Throttle.performed += ctx => _throttle = ctx.ReadValue<float>();
        _inputs.Airplane.Flaps.performed += ctx =>
        {
            _flaps += ctx.ReadValue<float>();
            _flaps = Mathf.Clamp(_flaps, 0.0f, 3.0f);
        };

        _inputs.Airplane.Brake.performed += ctx => _brake = ctx.ReadValue<float>();
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }
}
