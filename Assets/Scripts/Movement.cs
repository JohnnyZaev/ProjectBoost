using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustMultiplier = 1000f;
    [SerializeField] private float rotatePerSecond = 90f;
    
    private Rigidbody _rocketRigidbody;

    private void Start()
    {
        _rocketRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
            _rocketRigidbody.AddRelativeForce(Vector3.up * (thrustMultiplier * Time.deltaTime));
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            ApplyRotation(rotatePerSecond);
        else if (Input.GetKey(KeyCode.D))
            ApplyRotation(-rotatePerSecond);
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * (rotationThisFrame * Time.deltaTime));
        _rocketRigidbody.freezeRotation = false;
    }
}
