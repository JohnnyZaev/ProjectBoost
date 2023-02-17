using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Space");
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            Debug.Log("Left");
        if (Input.GetKey(KeyCode.D))
            Debug.Log("Right");
    }
}
