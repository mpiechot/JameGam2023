using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int SpawnPointIndex { get; private set; }

    [field: SerializeField]
    public int ScoreValue { get; private set; }

    public void Initialize(int spawnPointIndex)
    {
        SpawnPointIndex = spawnPointIndex;
    }

    public void Collect()
    {
        // Destroy the collectable
        Destroy(gameObject);

        // TODO: Increase the score
    }
}
