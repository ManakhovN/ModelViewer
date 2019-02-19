using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelMorphingInput : BasicModelInput
{
    [SerializeField] float multiplier = 0.01f;
    public override void OnOneFingerDrag(PointerEventData eventData)
    {
        foreach (var meshFilter in currentModel.GetComponentsInChildren<MeshFilter>())
        {
            MorphMesh(eventData.delta.x*multiplier,meshFilter);
        }
    }

    public void MorphMesh(float delta, MeshFilter meshFilter) {
        var sharedMesh = meshFilter.sharedMesh;
        var vertices = sharedMesh.vertices;
        var center = meshFilter.sharedMesh.bounds.center;
        var min = meshFilter.sharedMesh.bounds.min;
        var max = meshFilter.sharedMesh.bounds.max;
        for (int i = 0; i < vertices.Length; i++)
        {
            var point = vertices[i];
            float normalizedY = (point.y - min.y) / (max.y - min.y);
            float dx = point.x - center.x;
            float dz = point.z - center.z;
            float r = Mathf.Sqrt(dx*dx + dz*dz);
            float sin = dx / r;
            float cos = dz / r;
            r += delta*normalizedY;
            point.x = r * sin + center.x;
            point.z = r * cos + center.z;
            vertices[i] = point;
        }
        sharedMesh.vertices = vertices;
    }
}
