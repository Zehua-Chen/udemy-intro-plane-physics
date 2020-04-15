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

    [Header("Drag Properties")]
    [SerializeField]
    float _dragFactor = 0.01f;

    [SerializeField]
    float _angularDragFactor = 1.0f;

    const float MeterPerHourMultiplier = 3600.0f;

    float _startDrag = 0.0f;
    float _startAngularDrag = 0.0f;

    float _angleOfAttack = 0.0f;

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
        this.HandleRigidbodyTransform();
    }

    private void ForwardSpeed()
    {
        Vector3 localVelocity = this.transform.InverseTransformDirection(_rigidbody.velocity);
        _forwardSpeed = Mathf.Clamp(localVelocity.z, 0.0f, _maxForwardSpeed);
        _mph = _forwardSpeed * Airbody.MeterPerHourMultiplier;
    }

    private void Lift()
    {
        _angleOfAttack = Vector3.Dot(this.transform.forward, _rigidbody.velocity.normalized);
        _angleOfAttack = Mathf.Pow(_angleOfAttack, 2.0f);

        float t = _forwardSpeed / _maxForwardSpeed;
        Vector3 lift = this.transform.up
            * (_liftCurve.Evaluate(t) * _maxLiftPower) * _angleOfAttack;

        _rigidbody.AddForce(lift);
    }

    private void Drag()
    {
        _rigidbody.drag = _forwardSpeed * _dragFactor + _startDrag;
        _rigidbody.angularDrag = _forwardSpeed * _angularDragFactor + _startAngularDrag;
    }

    private void HandleRigidbodyTransform()
    {
        if (_rigidbody.velocity.magnitude > 1.0f)
        {
            _rigidbody.velocity = Vector3.Slerp(
                _rigidbody.velocity,
                this.transform.forward * _forwardSpeed,
                _angleOfAttack * _forwardSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(Quaternion.Slerp(
                _rigidbody.rotation,
                Quaternion.LookRotation(_rigidbody.velocity.normalized, transform.up),
                Time.deltaTime));
        }
    }
}
