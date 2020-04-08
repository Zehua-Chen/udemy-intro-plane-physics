using UnityEngine;

public class AirplaneControl : MonoBehaviour
{
    [SerializeField]
    AirplaneEngine[] _engines = null;

    [SerializeField]
    AirplaneWheel[] _wheels = null;

    [SerializeField]
    float _throttleSpeed = 20.0f;

    ProjectInputs _inputs = null;

    float _pitch = 0.0f;
    float _roll = 0.0f;
    float _yaw = 0.0f;
    float _flaps = 0;
    float _brake;

    private void Awake()
    {
        _inputs = new ProjectInputs();
        _inputs.Airplane.Pitch.performed += ctx => _pitch = ctx.ReadValue<float>();
        _inputs.Airplane.Roll.performed += ctx => _roll = ctx.ReadValue<float>();
        _inputs.Airplane.Yaw.performed += ctx => _yaw = ctx.ReadValue<float>();

        _inputs.Airplane.Flaps.performed += ctx =>
        {
            _flaps += ctx.ReadValue<float>();
            _flaps = Mathf.Clamp(_flaps, 0.0f, 3.0f);
        };

        _inputs.Airplane.Brake.performed += ctx => _brake = ctx.ReadValue<float>();
    }

    private void Update()
    {
        this.UpdateThrottle();
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void UpdateThrottle()
    {
        float throttleDelta = _inputs.Airplane.Throttle.ReadValue<float>() * _throttleSpeed;

        for (int i = 0; i < _engines.Length; i++)
        {
            _engines[i].Throttle += throttleDelta;
        }
    }
}
