using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform cameraReference;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float groundSlopeLimit;

    private Rigidbody characterPhysics;

    private void Start()
    {
        characterPhysics = GetComponent<Rigidbody>();
    }

    public void MoveXZ(float x, float z)
    {
        Vector3 nextVelocity = cameraReference.rotation *  new Vector3(x, 0, z) * moveSpeed;
        // Check for ground Normal and move character only if ground normal is within the slope limit.

        RaycastHit hit;
        if(Physics.Raycast(characterPhysics.position + nextVelocity * Time.fixedDeltaTime + Vector3.up, Vector3.down, out hit, 1.3f, groundLayer ))
        {
            if(Vector3.Dot(hit.normal, Vector3.up) > groundSlopeLimit)
                characterPhysics.velocity = nextVelocity + Vector3.up * characterPhysics.velocity.y;
            else
                characterPhysics.velocity = Vector3.up * characterPhysics.velocity.y;
        }
        else
            characterPhysics.velocity = nextVelocity + Vector3.up * characterPhysics.velocity.y;
    }
}
