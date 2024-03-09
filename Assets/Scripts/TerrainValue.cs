using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class TerrainValue : MonoBehaviour
{
    public static TerrainValue instance;
    public int Height = 121;
    public int Width = 121;
    public int maxMapHeight = 241;
    public int maxMapWidth = 241;
    public float scale;
    public Renderer textureRenderer;
    public float lacunarity;
    public float persistence;
    public int octaves;
    public int seed;
    public int seedOffset;
    public int Multiplier;
    public MeshCollider meshCollider;
    public int factorValue;
    public int collisionFactor;
    public MeshFilter _mF;
    public float[,] noiseMap;
    public Mesh mesh;
    [SerializeField] private Slider scalesl;
    [SerializeField] private Slider lacunaritysl;
    [SerializeField] private Slider persistencesl;
    [SerializeField] private Slider octavesSl;
    [SerializeField] private Slider seedsSl;
    [SerializeField] private Slider OffsetSl;
    
    [HideInInspector]
    public MeshGeneration meshGeneration;

    [HideInInspector]
    public MeshSimplification meshSimplification;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance ??= this;
        mesh = new Mesh();
        meshGeneration = new MeshGeneration();
        meshSimplification = new MeshSimplification();

    }

    public void MyButtonCall()
    {
        meshGeneration.MeshGenerate();
    }

    public void SetHeight(int height)
    {
        Height = height;
    }
    public void SetWidth(int width)
    {
        Width = width;
    }

    public void SetFactor(int factor)
    {
        factorValue = factor;
    }

    public void Update()
    {
        scale = scalesl.value;
        lacunarity = lacunaritysl.value;
        persistence = persistencesl.value;
        octaves = (int)octavesSl.value;
        seed = (int)seedsSl.value;
        seedOffset = (int)OffsetSl.value;
    }


}
