using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class AirplaneWheel : MonoBehaviour
{
    WheelCollider _wheelCollider = null;

    private void Awake()
    {
        _wheelCollider = GetComponent<WheelCollider>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _wheelCollider.motorTorque = 0.01f;
    }
}
