using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    
    public string order = "0z+ 1y+ 2z- 3y- 4x- 5x+";
    public Material [] material;
    private void Awake() 
    {
        Mesh mesh = new Mesh();
        mesh = this.gameObject.GetComponent<MeshFilter>().mesh;
        int[] triangles;
        mesh.subMeshCount = 6;
        this.gameObject.GetComponent<MeshRenderer>().materials = material;
        triangles = mesh.triangles;
        mesh.SetTriangles(GetRangeArray(triangles, 0, 5), 0);
        mesh.SetTriangles(GetRangeArray(triangles, 6, 11), 1);
        mesh.SetTriangles(GetRangeArray(triangles, 12, 17), 2);
        mesh.SetTriangles(GetRangeArray(triangles, 18, 23), 3);
        mesh.SetTriangles(GetRangeArray(triangles, 24, 29), 4);
        mesh.SetTriangles(GetRangeArray(triangles, 30, 35), 5);
    }
public int[] GetRangeArray(int[] SourceArray, int StartIndex, int EndIndex)
{
    try
{
    int[] result = new int[EndIndex - StartIndex + 1];
    for (int i = 0; i <= EndIndex - StartIndex; i++) 
    {
        result[i] = SourceArray[i + StartIndex];
    }
    return result;
}
    catch (IndexOutOfRangeException ex)
{
    throw new Exception(ex.Message);
}
}
}
