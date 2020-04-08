using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Airbody : MonoBehaviour
{
    [SerializeField]
    Transform _centerOfMass;

    Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = _centerOfMass.localPosition;
    }
}
