using UnityEngine;

public class AirplanePropeller : MonoBehaviour
{
    [SerializeField]
    float _blur1RPM = 300.0f;

    [SerializeField]
    float _blur2RPM = 1000.0f;

    [SerializeField]
    GameObject _realPropeller = null;

    [SerializeField]
    GameObject _blurPropeller = null;

    [SerializeField]
    Material _blur1Material = null;

    [SerializeField]
    Material _blur2Material = null;

    Renderer _blurPropellerRenderer = null;

    private void Awake()
    {
        _blurPropellerRenderer = _blurPropeller.GetComponent<Renderer>();
    }

    private void Start()
    {
        this.RotatePropeller(0.0f);
    }

    public void RotatePropeller(float rpm, float deltaTime = 1.0f)
    {
        float degreesPerSecond = ((rpm * 360.0f) / 60.0f) * deltaTime;
        this.transform.Rotate(Vector3.forward, degreesPerSecond);

        bool blurred = rpm > _blur1RPM;

        _realPropeller.SetActive(!blurred);
        _blurPropeller.SetActive(blurred);

        if (rpm > _blur2RPM)
        {
            _blurPropellerRenderer.material = _blur2Material;
        }
        else if (rpm > _blur1RPM && rpm < _blur2RPM)
        {
            _blurPropellerRenderer.material = _blur1Material;
        }
    }
}
