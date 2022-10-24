using UnityEngine;

// To rotate the rock behind the level
public class Rotation : MonoBehaviour
{
    float rotationDegree = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationDegree * Time.deltaTime);
    }
}
