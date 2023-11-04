using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingTargetAcquireror : MonoBehaviour
{
    [SerializeField] private float collectionDistance = 3;

    private Collectable[] collectablesInScene;
    private int targetCollectable = 0;

    [SerializeField] private Transform offsetIndicator;

    public float TargetDistance { get => targetCollectable < collectablesInScene.Length && collectablesInScene[targetCollectable] ? Vector3.Distance(transform.position, collectablesInScene[targetCollectable].transform.position) : 0; }

    private void FixedUpdate()
    {
        if(collectablesInScene == null || collectablesInScene.Length == 0 || !collectablesInScene[targetCollectable])
        {
            collectablesInScene = (Collectable[]) FindObjectsByType(typeof(Collectable), FindObjectsSortMode.None);
            Debug.Log("Dowsing: Refreshed Collectables Reference List.", gameObject);
        }

        float minDist = float.MaxValue;
        for(int i = 0; i < collectablesInScene.Length; i++)
        {
            float currentDistance = Vector3.Distance(transform.position, collectablesInScene[i].transform.position);
            if (currentDistance < minDist)
            {
                minDist = currentDistance;
                targetCollectable = i;
            }
        }

        // Check if it is in the scene and not destroyed yet
        if (targetCollectable < collectablesInScene.Length && collectablesInScene[targetCollectable]) 
        { 
            offsetIndicator.position = Vector3.Lerp(offsetIndicator.position, transform.position + (collectablesInScene[targetCollectable].transform.position - transform.position).normalized, 0.125f);
            offsetIndicator.LookAt(collectablesInScene[targetCollectable].transform);
        }

    }
    /// <summary>
    /// May return null if no target is valid
    /// </summary>
    /// <returns></returns>
    public Collectable GetCurrentTarget()
    {
        if (targetCollectable < collectablesInScene.Length && collectablesInScene[targetCollectable])
            return collectablesInScene[targetCollectable];
        else return null;
    }

    public bool IsInRange()
    {
        return targetCollectable < collectablesInScene.Length && collectablesInScene[targetCollectable] && Vector3.Distance(offsetIndicator.transform.position, collectablesInScene[targetCollectable].transform.position) <= collectionDistance;
    }

}
