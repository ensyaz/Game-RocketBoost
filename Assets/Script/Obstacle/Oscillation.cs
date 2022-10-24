using UnityEngine;

// To oscillate the obstacles using Sin
public class Oscillation : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 offset;
    [SerializeField] 
    Vector3 destinationPoint;

    [SerializeField] 
    float period = 2f;
    float movementFactor;
    

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Oscillate();
    }

    void Oscillate()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2;

        offset = destinationPoint * movementFactor;
        transform.position = startingPosition + offset;
    }
}
