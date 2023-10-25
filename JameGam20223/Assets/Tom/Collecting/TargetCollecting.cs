using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollecting : MonoBehaviour
{
    [SerializeField] private float collectionDistance;

    [SerializeField] private DowsingTargetAcquireror collectorMagnet;

    public void PerformCollection()
    {
        if(collectorMagnet.IsInRange(collectionDistance))
        {
            collectorMagnet.GetCurrentTarget()?.Collect();
        }
    }

}
