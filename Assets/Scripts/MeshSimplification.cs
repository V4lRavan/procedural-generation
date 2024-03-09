using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSimplification 
{



    private int mapSize=241;
    bool isFactorValid;

    // Start is called before the first frame update
    public void Init()
    {
        float factorCheck = mapSize-1;
        if(MapSizeIsInRange(factorCheck,TerrainValue.instance.factorValue))
        {
            isFactorValid = true;
            Debug.Log("it is true");
        }
        else
        {
            isFactorValid = false;
            Debug.Log("it is false");
        }
    }
    
    public void SimpleMeshGenerate(float[,] map)
    {
        Mesh newMesh = new Mesh();
        
        Vector3[] verts = new Vector3[TerrainValue.instance.Width * TerrainValue.instance.Height];
        Vector2[] uvs = new Vector2[TerrainValue.instance.Width * TerrainValue.instance.Height];
        
        int[] tris = new int[((TerrainValue.instance.Width - 1) * (TerrainValue.instance.Height - 1)) * 6];
        
        int vertIndex = 0;
        int triIndex = 0;
        
        int vertsPerLine=((TerrainValue.instance.Width -1)/ TerrainValue.instance.factorValue)+1;

        for (int x = 0; x < TerrainValue.instance.Width;x+= TerrainValue.instance.factorValue)
        {
            for (int y = 0; y < TerrainValue.instance.Height;y+= TerrainValue.instance.factorValue)
            {
                verts[vertIndex] = new Vector3(x, map[x, y] * TerrainValue.instance.Multiplier, y);
                uvs[vertIndex] = new Vector2((float)x/ TerrainValue.instance.Width, (float)y/ TerrainValue.instance.Height);

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

        TerrainValue.instance.mesh.vertices = verts;
        TerrainValue.instance.mesh.uv = uvs;
        TerrainValue.instance.mesh.triangles = tris;
        TerrainValue.instance.mesh.RecalculateNormals();  
        TerrainValue.instance._mF.sharedMesh = TerrainValue.instance.mesh;
    }

    bool MapSizeIsInRange(float dividend,float divisor)
    {
        return dividend % divisor == 0;
    }
}
