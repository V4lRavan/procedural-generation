using TreeEditor;
using UnityEngine;
public class MeshGeneration
{ 
    int[] tris;

    public void Init()
    {
        int triSize = ((TerrainValue.instance.Width - 1) * (TerrainValue.instance.Height - 1)) * 6;
        tris = new int[triSize];       
    }


   public void MeshGenerate()
    {
        Vector3[] verts = new Vector3[TerrainValue.instance.Width * TerrainValue.instance.Height];
        Vector2[] uvs = new Vector2[TerrainValue.instance.Width * TerrainValue.instance.Height];

        int vertIndex = 0;
        int triIndex = 0;
        for (int x = 0; x < TerrainValue.instance.Width; x++)
        {
            for (int y = 0; y < TerrainValue.instance.Height; y++)
            {
                verts[vertIndex] = new Vector3(x, TerrainValue.instance.noiseMap[x,y]*TerrainValue.instance.Multiplier, y);
                uvs[vertIndex] = new Vector2((float)x/ TerrainValue.instance.Width, (float)y/ TerrainValue.instance.Height);

             
                
                    if (x < TerrainValue.instance.Width - 1 && y < TerrainValue.instance.Height - 1)
                    {
                        tris[triIndex] = vertIndex;
                        tris[triIndex + 1] = vertIndex + TerrainValue.instance.Width +1;
                        tris[triIndex + 2] = vertIndex + TerrainValue.instance.Width;
                        tris[triIndex + 3] = vertIndex;
                        tris[triIndex + 4] = vertIndex + 1;
                        tris[triIndex + 5] = vertIndex + TerrainValue.instance.Width +1;
                        
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
}
