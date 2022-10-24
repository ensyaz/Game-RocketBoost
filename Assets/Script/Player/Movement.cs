using UnityEngine;
using UnityEngine.UI;

// To move the player with UI buttons
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] AudioClip engineThrust;
    [SerializeField] ParticleSystem mainThrustParticle;

    float horizontalMove;
    float thrustRate = 1000f;
    float rotationRate = 100f;

    bool UpButton = false;
    bool LeftRotationButton = false;
    bool RightRotationButton = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (UpButton)
        {
            StartThrust();
        }

        else
        {
            StopThrust();
        }
    }

    void ProcessRotation()
    {
        if (LeftRotationButton)
        {
            ApplyRotation(-rotationRate);
        }

        if (RightRotationButton)
        {
            ApplyRotation(rotationRate);
        }
    }

    // OnClick functions are connected to UI buttons via editor
    // If movement buttons get touched, certain parameters get true
    public void OnClickThrust()
    {
        UpButton = true;
    }

    public void OnClickStopThrust()
    {
        UpButton = false;
    }

    public void OnClickLeftRotation()
    {
        LeftRotationButton = true;
    }

    public void OnClickLeftRotationStop()
    {
        LeftRotationButton = false;
    }

    public void OnClickRightRotation()
    {
        RightRotationButton = true;
    }

    public void OnClickRightRotationStop()
    {
        RightRotationButton = false;
    }

    public void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * thrustRate * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrust);
        }

        if (!mainThrustParticle.isPlaying)
        {
            mainThrustParticle.Play();
        }
    }

    public void StopThrust()
    {
        audioSource.Stop();
        mainThrustParticle.Stop();
    }

    void ApplyRotation(float horizontalDirection) 
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * horizontalDirection * Time.deltaTime);
        rb.freezeRotation = false;
    }


}
