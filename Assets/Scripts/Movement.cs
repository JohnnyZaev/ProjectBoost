using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustMultiplier = 1000f;
    
    private Rigidbody _objectRigidbody;

    private void Start()
    {
        _objectRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
            _objectRigidbody.AddRelativeForce(Vector3.up * (thrustMultiplier * Time.deltaTime));
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            Debug.Log("Left");
        if (Input.GetKey(KeyCode.D))
            Debug.Log("Right");
    }
}
