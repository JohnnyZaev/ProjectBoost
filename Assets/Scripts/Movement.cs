using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Space");
    }
}
