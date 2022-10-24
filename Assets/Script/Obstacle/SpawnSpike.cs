using UnityEngine;

// To spawn spike obstacle if spike got destroyed
public class SpawnSpike : MonoBehaviour
{
    public Vector3 startingLocation;
    public GameObject prefab;

    // Spike Script returns true to this variable if spike is destroyed
    public static bool isDestroyed = false;

    void Update()
    {
        spawnSpike();
    }

    public void spawnSpike()
    {
        if(isDestroyed)
        {
            Instantiate(prefab, startingLocation, Quaternion.identity);
            isDestroyed = false;
        }
    }
}
