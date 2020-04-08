using UnityEngine;

public class AirplaneEngine : MonoBehaviour
{
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

    [SerializeField]
    Rigidbody _rigidbody = null;

    private void FixedUpdate()
    {
        float power = _maxForce * _powerCurve.Evaluate(_throttle / _maxThrottle);
        Vector3 force = this.transform.forward * power;

        _rigidbody.AddForceAtPosition(force, this.transform.position);
    }
}
