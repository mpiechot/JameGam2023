using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private CameraMovement cameraMovement;

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float camXInput = Input.GetAxis("CamHorizontal");
        float camYInput = Input.GetAxis("CamVertical");
        
        characterAnimation.SetWalking(false);

        if (Mathf.Abs(xInput) + Mathf.Abs(zInput) > 0.25f)
        {
            // Move Character in the XZ Plane on the ground
            characterMovement.MoveXZ(xInput, zInput);
            characterAnimation.SetFacingRotation(new Vector3(xInput, 0, zInput), Vector3.up); // Move this function, but where?
            characterAnimation.SetWalking(true);
        }
        else characterMovement.MoveXZ(0, 0);

        if (Mathf.Abs(camXInput) > 0.2f) cameraMovement.Rotate(camXInput);
        else cameraMovement.Rotate(0);
        if(Mathf.Abs(camYInput) > 0.5f) cameraMovement.Zoom(camYInput);
        else cameraMovement.Zoom(0);

    }
}
