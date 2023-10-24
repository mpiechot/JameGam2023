using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingRod : MonoBehaviour
{

    [SerializeField] private Transform origin;

    void Update()
    {
        transform.position = origin.position;    
    }
}
