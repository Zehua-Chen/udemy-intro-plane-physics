using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirplaneControl : MonoBehaviour
{
    [SerializeField]
    AirplaneEngine[] _engines = null;

    [SerializeField]
    AirplaneWheel[] _wheels = null;

    [SerializeField]
    float _throttleSpeed = 20.0f;

    [SerializeField]
    float _pitchSpeed = 1500.0f;

    [SerializeField]
    float _rollSpeed = 1500.0f;

    [SerializeField]
    float _yawSpeed = 1500.0f;

    ProjectInputs _inputs = null;

    float _flaps = 0;
    float _brake;
    Rigidbody _rigidbody = null;

    public float PitchAngle { get; private set; } = 0.0f;
    public float RollAngle { get; private set; } = 0.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _inputs = new ProjectInputs();
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

    private void FixedUpdate()
    {
        this.Pitch();
        this.Roll();
        this.Yaw();
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

    private void Pitch()
    {
        Vector3 forward = transform.forward;
        forward.y = 0.0f;
        forward = forward.normalized;

        this.PitchAngle = Vector3.Angle(forward, this.transform.forward);

        Vector3 pitchTorque = this.transform.right
            * _inputs.Airplane.Pitch.ReadValue<float>() * _pitchSpeed;

        _rigidbody.AddTorque(pitchTorque);
    }

    private void Roll()
    {
        Vector3 right = transform.right;
        right.y = 0.0f;
        right = right.normalized;

        this.RollAngle = Vector3.Angle(right, this.transform.right);

        Vector3 rollTorque = this.transform.forward
            * _inputs.Airplane.Roll.ReadValue<float>() * _rollSpeed;

        _rigidbody.AddTorque(rollTorque);
    }

    private void Yaw()
    {
        Vector3 yawTorque = this.transform.up
            * _inputs.Airplane.Yaw.ReadValue<float>() * _yawSpeed;

        _rigidbody.AddTorque(yawTorque);
    }
}
