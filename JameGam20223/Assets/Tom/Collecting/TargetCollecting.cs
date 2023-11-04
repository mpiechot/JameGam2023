using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollecting : MonoBehaviour
{
    [SerializeField] private DowsingTargetAcquireror collectorMagnet;

    public void PerformCollection()
    {
        if(collectorMagnet.IsInRange())
        {
            collectorMagnet.GetCurrentTarget()?.Collect();
        }
    }

}
