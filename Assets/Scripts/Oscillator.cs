using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0, 1)] private float movementFactor;
    
    
    private Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        var offset = movementVector * movementFactor;
        transform.position = _startingPosition + offset;
    }
}
