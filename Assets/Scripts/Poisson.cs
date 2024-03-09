using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisson : MonoBehaviour
{
    public static Poisson instance;
    [SerializeField] GameObject tree;
    public int iterations;

    List<Vector3> mitchellsPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {  
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Generate();
        }
    }

    void PlaceTrees()
    {
        for(int i = 0; i < mitchellsPositions.Count; i++)
        {
            RaycastHit hit;
            Vector3 newPos = mitchellsPositions[i];
            newPos.y = 1000;
            GameObject latestTree=Instantiate(tree,newPos,Quaternion.identity);

            if(Physics.Raycast(latestTree.transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                float distanceToFloor = hit.distance;

                newPos.y-= distanceToFloor;
                latestTree.transform.position = newPos;

            }
        }
    }
   
    Vector3[] GenerateRandomPoints()
    {
        Vector3[] _positions = new Vector3[10 * 10];

        for (int i = 0; i < iterations; i++)
        {
            float ranX = Random.Range(0, TerrainValue.instance.Width); // 0, width
            float ranY = Random.Range(0, TerrainValue.instance.Height); // 0, height
            _positions[i] = new Vector3(ranX, ranY);
        }

        return _positions;
    }

    Vector3 GetRandomPoint()
    {
        float ranX = Random.Range(0,TerrainValue.instance.Width);
        float ranY = Random.Range(0,TerrainValue.instance.Height);

        return new Vector3(ranX, 0, ranY);
    }

    public void Generate()
    {
        float bestDistance = 0;
        Vector3 bestCandidate = Vector3.zero;

        for (int i = 0; i < 10; i++)
        {
            bestDistance = 0;
            bestCandidate = Vector3.zero;

            for (int j = 0; j < 10; j++)
            {
                Vector3 a = GetRandomPoint();
                Vector3 closestPoint = FindClosestSample(a);
                float dist = Distance(a, closestPoint);

                if (dist > bestDistance)
                {
                    bestDistance = dist;
                    bestCandidate = a;
                }
            }

            Vector3 newPos = bestCandidate;
            newPos.y = 0;
            newPos.z = bestCandidate.z;

            mitchellsPositions.Add(newPos);

            //Vector3 spawnPos = new Vector3(selectedPositions[i].x, 0, selectedPositions[i].y);
            //Instantiate(orb, spawnPos, Quaternion.identity);            
        }
        PlaceTrees();
    }

    float Distance(Vector3 pointA, Vector3 pointB)
    {
        float d = Vector3.Distance(pointA, pointB);
        return d;
    }

    Vector3 FindClosestSample(Vector3 candidate)
    {
        float currentClosest = float.MaxValue;

        Vector3 closestSample = Vector3.zero;

        for (int i = 0; i < mitchellsPositions.Count; i++)
        {
            float dist = Distance(mitchellsPositions[i], candidate);

            if (dist < currentClosest)
            {
                currentClosest = dist;
                closestSample = mitchellsPositions[i];
            }
        }

        return closestSample;
    }
}
