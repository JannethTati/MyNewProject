using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform[] spawnPoints;
    public float respawnTime = 5f;

    void Start()
    {
        SpawnHearts();
    }

    void SpawnHearts()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(heartPrefab, point.position, Quaternion.identity);
        }

        Invoke("SpawnHearts", respawnTime);
    }
}
