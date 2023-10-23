using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingTestRotator : MonoBehaviour
{
    [SerializeField] private Transform origin;

    void FixedUpdate()
    {
        transform.position = origin.position + Quaternion.Euler(0,Time.time * 180f, 0) * Vector3.right * 0.5f;
    }
}
