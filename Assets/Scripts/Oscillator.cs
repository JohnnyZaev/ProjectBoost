using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0, 1)] private float movementFactor;
    [SerializeField] private float period = 2f;
    
    
    private Vector3 _startingPosition;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        var cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        var rawSinWave = Mathf.Sin(tau * cycles);

        movementFactor = (rawSinWave + 1) / 2;
        
        var offset = movementVector * movementFactor;
        transform.position = _startingPosition + offset;
    }
}
