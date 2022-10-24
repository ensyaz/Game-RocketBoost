using UnityEngine;

// To rotate and move the objects till certain range and instantiate 
public class RotationMove : MonoBehaviour
{
    [SerializeField] float rotationDegree = -5f;
    [SerializeField] float yRange = -7.5f;

    [SerializeField] Vector3 coordParam = new Vector3(1f, -1f, 0f);
    [SerializeField] Vector3 startingLocation = new Vector3(0, 0, 0);

    [SerializeField] GameObject prefab;

    float yCoordinate = 0f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
        ProcessCreateObject(); 
    }

    void Move()
    {
        transform.position = transform.position + coordParam * Time.deltaTime;
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward * rotationDegree * Time.deltaTime);
    }

    void ProcessCreateObject()
    {
        yCoordinate = transform.position.y;

        if (Equal(yCoordinate, yRange, 0.1f))
        {
            CreateObject();
        }
    }

    void CreateObject()
    {
        Instantiate(prefab, startingLocation, Quaternion.identity);
        Destroy(gameObject);
    }

    bool Equal(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
}
