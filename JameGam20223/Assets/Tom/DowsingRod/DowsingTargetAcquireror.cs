using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingTargetAcquireror : MonoBehaviour
{

    private Collectable[] collectablesInScene;
    private int targetCollectable = 0;

    [SerializeField] private Transform offsetIndicator;

    private void Update()
    {
        if(collectablesInScene == null || collectablesInScene.Length == 0)
        {
            collectablesInScene = (Collectable[]) FindObjectsByType(typeof(Collectable), FindObjectsSortMode.None);
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
            offsetIndicator.position = transform.position + (collectablesInScene[targetCollectable].transform.position - transform.position).normalized;
        }

    }

}
