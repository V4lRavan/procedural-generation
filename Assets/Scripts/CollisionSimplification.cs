using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSimplification 
{
    public void SimpleMeshGenerate(float[,] map)
    {
        Vector3[] verts = new Vector3[TerrainValue.instance.Width * TerrainValue.instance.Height];
        
        int[] tris = new int[((TerrainValue.instance.Width - 1) * (TerrainValue.instance.Height - 1)) * 6];
        
        int vertIndex = 0;
        int triIndex = 0;
        
        int vertsPerLine=((TerrainValue.instance.Width -1)/ TerrainValue.instance.collisionFactor)+1;

        for (int x = 0; x < TerrainValue.instance.Width;x+= TerrainValue.instance.collisionFactor)
        {
            for (int y = 0; y < TerrainValue.instance.Height;y+= TerrainValue.instance.collisionFactor)
            {
                verts[vertIndex] = new Vector3(x, map[x, y] * TerrainValue.instance.Multiplier, y);

                if (x < TerrainValue.instance.Width - 1 && y < TerrainValue.instance.Height - 1)
                {
                    tris[triIndex] = vertIndex;
                    tris[triIndex + 1] = vertIndex+vertsPerLine+1;
                    tris[triIndex + 2] = vertIndex + vertsPerLine;
                    tris[triIndex + 3] = vertIndex;
                    tris[triIndex + 4] = vertIndex+1;
                    tris[triIndex + 5] = vertIndex+vertsPerLine+1;

                    triIndex += 6;
                }

                vertIndex++;
            }
        }

        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;

        TerrainValue.instance.meshCollider.sharedMesh = mesh;
    }
}
