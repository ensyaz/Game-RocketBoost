using UnityEngine;

/* To move the spike obstacle and gives true boolean to isDestroyed variable
   if spike collides to obstacle*/
public class Spike : MonoBehaviour
{
    Vector3 currentPosition;
    Vector3 offset = new Vector3(0f, 10f, 0f);

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        moveSpike();
    }

    void moveSpike()
    {
        transform.position = currentPosition + offset * Time.deltaTime;
        currentPosition = transform.position;
    }

    // Destroys the spike if collides with obstacle and returns true to isDestroyed variable
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            SpawnSpike.isDestroyed = true;
        }
    }




}
