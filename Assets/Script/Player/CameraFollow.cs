using UnityEngine;

// To follow the player with the camera
public class CameraFollow : MonoBehaviour
{
    float smoothSpeed = 10f;
    [SerializeField] 
    Transform target;

    Vector3 offset = new Vector3(0, 1, -12);
    Vector3 desiredPosition;
    Vector3 smoothedPosition;

    void FixedUpdate()
    {
        trackCamera();
    }

    void trackCamera()
    {
        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }


}
