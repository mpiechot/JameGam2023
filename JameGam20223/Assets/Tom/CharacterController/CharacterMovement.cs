using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform cameraReference;

    private Rigidbody characterPhysics;

    private void Start()
    {
        characterPhysics = GetComponent<Rigidbody>();
    }

    public void MoveXZ(float x, float z)
    {
        characterPhysics.velocity = cameraReference.rotation *  new Vector3(x, 0, z) * moveSpeed;
    }
}
