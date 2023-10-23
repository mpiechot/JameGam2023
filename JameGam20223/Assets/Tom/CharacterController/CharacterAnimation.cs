using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Transform cameraReference;
    [SerializeField] private Animator animator;

    private bool isWalking;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetFacingRotation(Vector3 forward, Vector3 groundNormal)
    {
        transform.rotation = Quaternion.LookRotation(cameraReference.rotation * forward, groundNormal);
    }

    public void SetWalking(bool walking)
    {
        if(isWalking != walking)
        {
            animator.SetBool("Walking", walking);
            isWalking = walking;
        }
    }

}
