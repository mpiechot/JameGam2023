using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float rotationVelocity;
    [SerializeField] private float zoomVelocity;

    [SerializeField] private Transform cameraTransform;

    private float zoomPosition;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.3f);
    }

    public void Rotate(float amount)
    {
        transform.Rotate(Vector3.up, rotationVelocity * amount);
    }

    public void Zoom(float amount)
    {
        zoomPosition += amount * zoomVelocity;
        zoomPosition = Mathf.Clamp01(zoomPosition);
        cameraTransform.localPosition = new Vector3(0, 2, -5) + new Vector3(0, 8, -10) * (1 - zoomPosition);
        cameraTransform.localRotation = Quaternion.Euler(5 + 20 * (1 - zoomPosition), 0, 0);
    }

}
