using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelUtils : MonoBehaviour
{
    public static GameObject[] LoadFromResources()
    {
       return Resources.LoadAll<GameObject>("Models/OBJ/");
    }

    public static string GetModelInfo(GameObject go) {
        var meshes = go.GetComponentsInChildren<MeshFilter>();
        return "<b>"+go.name + "</b>\n" +
            "Meshes count: " + meshes.Length + '\n' +
            "Vertices count: " + GetNumberOfVertices(meshes) + '\n' +
            "Triangles count: " + GetNumberOfTriangles(meshes) + '\n' +
            "Bound max: " + GetBoundMax(meshes) + '\n' +
            "Bound min: " + GetBoundMin(meshes) + '\n';
    }

    public static int GetNumberOfTriangles(MeshFilter[] meshFilters)
    {
        int trianglesCount = 0;
        foreach (var meshFilter in meshFilters)
        {
            trianglesCount += meshFilter.sharedMesh.triangles.Length/3;
        }
        return trianglesCount;
    }

    public static int GetNumberOfVertices(MeshFilter[] meshFilters) {
        int verticesCount = 0;
        foreach (var meshFilter in meshFilters) {
            verticesCount += meshFilter.sharedMesh.vertices.Length;
        }
        return verticesCount;
    }

    public static Vector3 GetBoundMax(MeshFilter[] meshFilters)
    {
        Vector3 result = GetMeshWorldBoundMax(meshFilters[0]);
        for (int i = 1; i < meshFilters.Length; i++)
        {
            var temp = GetMeshWorldBoundMax(meshFilters[i]);
            if (temp.x > result.x)
                result.x = temp.x;
            if (temp.y > result.y)
                result.y = temp.y;
            if (temp.z > result.z)
                result.z = temp.z;
        }
        return result;
    }

    public static Vector3 GetBoundMin(MeshFilter[] meshFilters)
    {
        Vector3 result = GetMeshWorldBoundMin(meshFilters[0]);
        for (int i = 1; i < meshFilters.Length; i++)
        {
            var temp = GetMeshWorldBoundMin(meshFilters[i]);
            if (temp.x < result.x)
                result.x = temp.x;
            if (temp.y < result.y)
                result.y = temp.y;
            if (temp.z < result.z)
                result.z = temp.z;
        }
        return result;
    }

    public static Vector3 GetMeshWorldBoundMax(MeshFilter meshFilter)
    {
        var mesh = meshFilter.sharedMesh;
        return meshFilter.transform.TransformPoint(mesh.bounds.max);
    }

    public static Vector3 GetMeshWorldBoundMin(MeshFilter meshFilter)
    {
        var mesh = meshFilter.sharedMesh;
        return meshFilter.transform.TransformPoint(mesh.bounds.min);
    }

    public static Vector3 CalculateCenter(MeshFilter[] meshFilters)
    {
        Vector3 result = Vector3.zero;
        foreach (var m in meshFilters)
        {
            result += m.sharedMesh.bounds.center;
        }
        return result / meshFilters.Length;
    }

    public static float GetClosestZ(MeshFilter[] meshFilters)
    {
        float result = float.MaxValue;
        foreach (var m in meshFilters)
        {
            float temp = GetMeshWorldBoundMin(m).z;
            if (temp < result)
                result = temp;
        }
        return result;
    }
}
