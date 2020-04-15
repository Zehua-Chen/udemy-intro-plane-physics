using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Airbody : MonoBehaviour
{
    [SerializeField]
    Transform _centerOfMass;

    [SerializeField]
    float _maxForwardSpeed = 0.0f;

    [SerializeField]
    float _forwardSpeed = 0.0f;

    [Header("Lift Properties")]
    [SerializeField]
    float _maxLiftPower = 5.0f;

    [SerializeField]
    AnimationCurve _liftCurve = null;

    const float MeterPerHourMultiplier = 3600.0f;

    float _startDrag = 0.0f;
    float _startAngularDrag = 0.0f;

    float _mph = 0.0f;

    Rigidbody _rigidbody = null;

    public float MPH => _mph;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = _centerOfMass.localPosition;

        _startDrag = _rigidbody.drag;
        _startAngularDrag = _rigidbody.angularDrag;
    }

    private void FixedUpdate()
    {
        this.ForwardSpeed();
        this.Lift();
        this.Drag();
    }

    private void ForwardSpeed()
    {
        Vector3 localVelocity = this.transform.InverseTransformDirection(_rigidbody.velocity);
        _forwardSpeed = Mathf.Clamp(localVelocity.z, 0.0f, _maxForwardSpeed);
        _mph = _forwardSpeed * Airbody.MeterPerHourMultiplier;
    }

    private void Lift()
    {
        float t = _forwardSpeed / _maxForwardSpeed;
        Vector3 lift = this.transform.up * (_liftCurve.Evaluate(t) * _maxLiftPower);

        Debug.Log(lift);

        _rigidbody.AddForce(lift);
    }

    private void Drag()
    {
    }
}
