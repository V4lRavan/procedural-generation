using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TerrainManager : MonoBehaviour
{
   public static TerrainManager instance;
   Perlin perlin= new Perlin();
   MeshGeneration meshGeneration=new MeshGeneration();
   MeshSimplification meshSimplification =new MeshSimplification();
   
   CollisionSimplification collisionSimplification =new CollisionSimplification();
   
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance ??= this;
    }

    public void GeneratePerlinMap()
    {
        perlin.Generate();
    }

    public void GenerateMesh()
    {
        meshGeneration.Init();
        meshGeneration.MeshGenerate();
    }

    public void SimpleMeshGen()
    {
        meshSimplification.Init();
        meshSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
    }

    public void VisualMeshButton()
    {
        perlin.Generate();
        meshSimplification.Init();
        meshSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
    }

    public void CollisionMeshGenerate()
    {
        collisionSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
    }

    private void LateUpdate()
    {
       
        // Generate the VISUAL mesh. 
        if (Input.GetMouseButtonUp(0))
        {
            perlin.Generate();
            meshSimplification.Init();
            meshSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
            collisionSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
        }

        //{
        //    perlin.Generate();
        //    meshSimplification.Init();
        //    meshSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
        //}
        
        // Generate the COLLISION mesh.
        if (Input.GetKeyDown(KeyCode.S))
        {
            collisionSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
        }
    }

}
