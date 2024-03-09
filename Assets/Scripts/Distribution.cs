using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribution : MonoBehaviour
{
    [SerializeField] GameObject orb;
    List<Vector2[,]>_positions = new List<Vector2[,]>();

    public int iterations;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector2[,] GetRandomPoint()
    {
        Vector2[,] _positions = new Vector2[10, 10];

        for(int x = 0; x < 10; x++)
        {
            for(int y = 0; y< 10; y++)
            {
                float ranX = Random.Range(0, 10);
                float ranY = Random.Range(0, 10);
                _positions[x, y] = new Vector2(ranX, ranY);
            }
        }        

        return  _positions;
    }
    void Generate()
    {
        Vector2[,] newPos = GetRandomPoint();

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Vector3 spawnPos = new Vector3(newPos[x,y].x, 0, newPos[x, y].y);
                Instantiate(orb, spawnPos, Quaternion.identity);
            }
        }
    }
}
