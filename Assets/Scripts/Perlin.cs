using UnityEngine;
using UnityEngine.UI;

public class Perlin
{
 
    // Start is called before the first frame update

    public float[,] NoiseGeneration(int width, int height, float lucunarity,float persistence, int octaves,int seed,int seedOffset)
    {
        float [,] t =new float[height, width];
        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;
        float seedValue = GenerateSeedValue(5);

        for(int x=0;x<width; x++)
        {
            for(int y=0;y<height;y++)
            {
                float val=0;
                float frequency = 1;
                float amplitude = 1;
                float maxValue = 0;

                for (int j= 0; j < octaves; j++)
                { 
                    float xSample = x / TerrainValue.instance.scale + seed;
                    float ySample = y / TerrainValue.instance.scale + seed;
                    float perlinValue = Mathf.PerlinNoise(xSample * frequency, ySample * frequency) * amplitude;

                    val = val + perlinValue;

                    maxValue = maxValue + amplitude;
                    amplitude = amplitude * persistence;
                    frequency = frequency * lucunarity;                        
                }


                if(val>maxHeight) maxHeight = val;

                if (val < minHeight) minHeight = val;

                t[x, y] = val;
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                t[x, y] = Mathf.InverseLerp(minHeight, maxHeight, t[x, y]);

                t[x, y] = Mathf.Clamp(t[x,y],0.3f, 1);
            }
        }
        return t;
    }

  
    public void Generate()
    {
       
            TerrainValue.instance.noiseMap = NoiseGeneration(TerrainValue.instance.Width,TerrainValue.instance.Height, TerrainValue.instance.lacunarity, TerrainValue.instance.persistence, TerrainValue.instance.octaves, TerrainValue.instance.seed, TerrainValue.instance.seedOffset);
            DrawNoise(TerrainValue.instance.noiseMap);
            //TerrainValue.instance.meshGeneration.MeshGenerate();
            //TerrainValue.instance.meshSimplification.SimpleMeshGenerate(TerrainValue.instance.noiseMap);
       
    }
    void DrawNoise(float[,]noiseMap)
    {
        int mapWidth, mapHeight;
        mapWidth = noiseMap.GetLength(0);
        mapHeight = noiseMap.GetLength(1);

        Texture2D tex=new Texture2D(mapWidth,mapHeight);

        Color[] colourMap = new Color[mapWidth * mapHeight];

        ColourMap(noiseMap,ref colourMap);
        tex.SetPixels(colourMap);

        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Bilinear;

        tex.Apply();
        TerrainValue.instance.textureRenderer.sharedMaterial.mainTexture = tex;
    }

    void ColourMap(float[,] noiseArray,ref Color[] colourMap)
    {
        int width = noiseArray.GetLength(0);
        int height = noiseArray.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
               if (noiseArray[x, y] < 0.1f)
               {
                   colourMap[y * width + x] = Color.blue;
               }
               else if (noiseArray[x,y]<=0.3f)
               {
                    colourMap[y * width + x] = Color.blue;
               }
               else if (noiseArray[x,y]<=0.5f)
               {
                    colourMap[y * width + x] = Color.green;
               }
               else if (noiseArray[x, y] <= 0.7f)
               {
                    colourMap[y * width + x] = Color.grey;
               }
               else if (noiseArray[x,y]<=1f)
               {
                    colourMap[y * width + x] = Color.white;
               }     
            }
        }
    }

    float GenerateSeedValue(int seed)
    {
        System.Random RandValue = new System.Random(seed);
        float val=RandValue.Next(-100000,100000);

        return val;
    }

   public float GetScale()
    {
        return TerrainValue.instance.scale;
    }

}
