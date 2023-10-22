using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    [SerializeField]
    private Transform spawnedCollectablesParent;

    [SerializeField]
    private List<Collectable> collectibles;

    [SerializeField]
    private List<GameObject> spawnPoints;

    [SerializeField, Range(0, 100)]
    private int maxCollectibles = 1;

    private List<Collectable> spawnedCollectibles = new List<Collectable>();

    // Update is called once per frame
    void Update()
    {
        if (spawnedCollectibles.Count == maxCollectibles)
        {
            // Nothing to do, we have reached the max number of collectibles
            return;
        }

        int tryCount = 0;
        while (spawnedCollectibles.Count < maxCollectibles)
        {
            if (AllSpawnPointsOccupied())
            {
                return;
            }
            tryCount++;

            if (TryAddCollectible())
            {
                tryCount = 0;
            }
            else if (tryCount > 10)
            {
                // We tried 10 times to add a collectible, but failed every time
                // This means that all spawn points are occupied
                return;
            }
        }

    }

    private bool AllSpawnPointsOccupied()
    {
        return spawnPoints.Select((spawnPoint, index) => spawnedCollectibles.Any(collecible => collecible.SpawnPointIndex == index)).All(state => state);
    }

    private bool TryAddCollectible()
    {
        // Get a random collectible
        var collectible = collectibles[Random.Range(0, collectibles.Count)];

        // Get a random spawn point, that is not already occupied
        var spawnPointIndex = default(int);
        var tryCount = 0;
        do
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Count);
            tryCount++;
        }
        while (SpawnPointIsOccupied(spawnPointIndex) && tryCount < 10);

        if (SpawnPointIsOccupied(spawnPointIndex))
        {
            return false;
        }

        // Spawn the collectible
        var spawnedCollectible = Instantiate(collectible, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity, spawnedCollectablesParent);
        spawnedCollectible.Initialize(spawnPointIndex);

        // Add the collectible to the list of spawned collectibles
        spawnedCollectibles.Add(spawnedCollectible);

        return true;
    }

    private bool SpawnPointIsOccupied(int spawnPoint)
    {
        return spawnedCollectibles.Any(spawnedCollectible => spawnedCollectible.SpawnPointIndex == spawnPoint);
    }
}
