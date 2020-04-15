using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirplaneEngine : MonoBehaviour
{
    [Header("Engine Properties")]
    [SerializeField]
    float _maxForce = 200.0f;
    [SerializeField]
    float _maxRPM = 2550.0f;

    [SerializeField]
    float _maxThrottle = 100.0f;

    [SerializeField]
    AnimationCurve _powerCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    [SerializeField]
    float _throttle = 0.0f;

    [Header("Propeller")]
    [SerializeField]
    AirplanePropeller _propeller = null;

    Rigidbody _rigidbody = null;

    public float Throttle
    {
        get
        {
            return _throttle;
        }
        set
        {
            _throttle = Mathf.Clamp(value, 0.0f, _maxThrottle);
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float finalThrottle = _powerCurve.Evaluate(_throttle / _maxThrottle);
        float power = _maxForce * finalThrottle;
        Vector3 force = this.transform.forward * power;

        float currentRPM = _maxRPM * finalThrottle;
        _propeller.RotatePropeller(currentRPM, Time.deltaTime);

        _rigidbody.AddForce(force);
    }
}
