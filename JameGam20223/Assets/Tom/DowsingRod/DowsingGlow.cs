using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowsingGlow : MonoBehaviour
{
    [field: SerializeField] private DowsingTargetAcquireror targetAcquireror;
    [field: SerializeField] private MeshRenderer glowRenderer;

    private Color defaultColor;
    private void Start()
    {
        defaultColor = glowRenderer.material.color;
    }

    void Update()
    {
        defaultColor.a = targetAcquireror.IsInRange() ? 0.3f / (targetAcquireror.TargetDistance + 0.01f) : 0;
        glowRenderer.material.SetColor("_Color",  defaultColor);
    }
}
