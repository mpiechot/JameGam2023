using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMeshDeform : MonoBehaviour
{
    [SerializeField] private Transform origin;

    [SerializeField] private Transform target;
    [SerializeField] private Transform offsetTarget;

    private MeshFilter meshFilter;

    private Vector3[] vertecies;
    private float[] targetInfluence;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        vertecies = meshFilter.mesh.vertices;
        targetInfluence = new float[vertecies.Length];

        for(int i = 0; i < vertecies.Length; i++)
        {
            targetInfluence[i] = 100 / Mathf.Pow(Vector3.Distance(Vector3.Scale(vertecies[i], transform.localScale), target.localPosition), 10);
        }
    }

    private void Update()
    {
         transform.position = origin.position;
    }

    void FixedUpdate()
    {
        Vector3[] transformedVertices = new Vector3[vertecies.Length];
        for (int i = 0; i < vertecies.Length; i++)
        {
            transformedVertices[i] = vertecies[i] + Vector3.Scale(offsetTarget.position - target.position, new Vector3(1.0f/transform.localScale.x, 1.0f / transform.localScale.y, 1.0f / transform.localScale.z)) * targetInfluence[i];
        }
        meshFilter.mesh.vertices = transformedVertices;
    }

    //private void OnDrawGizmos()
    //{
    //    for (int i = 0; i < vertecies.Length; i++)
    //    {
    //        Gizmos.color = Color.HSVToRGB(Mathf.Clamp01(targetInfluence[i]),1,1);
    //        Gizmos.DrawSphere(transform.position + Vector3.Scale(vertecies[i], transform.localScale), 0.05f);
    //    }

    //    Vector3[] transformedVertices = new Vector3[vertecies.Length];
    //    for (int i = 0; i < vertecies.Length; i++)
    //    {
    //        transformedVertices[i] = vertecies[i] + Vector3.Scale(offsetTarget.position - target.position, new Vector3(1.0f / transform.localScale.x, 1.0f / transform.localScale.y, 1.0f / transform.localScale.z)) * targetInfluence[i];
    //        Gizmos.color = Color.HSVToRGB(Mathf.Clamp01(targetInfluence[i]), 1, 1);
    //        Gizmos.DrawSphere(transform.position + Vector3.Scale(transformedVertices[i], transform.localScale), 0.05f);
    //    }
    //}

}
