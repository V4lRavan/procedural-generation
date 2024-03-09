using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class L_System : MonoBehaviour
{
    public static L_System instance;
    [SerializeField] GameObject turtle;
    [SerializeField] Transform SpawnPos ;
    string axiom = "X";
    int iterations = 6;
    [SerializeField] float length = 0.1f;
    [SerializeField] float angle = 25.0f;
    Dictionary<char, string> recursionRules = new Dictionary<char, string>();
    [SerializeField] LineRenderer lineRenderer;

    //public Transform tree;

    public struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;

    }
    Stack<TransformData> _transformData = new Stack<TransformData>();
    // Start is called before the first frame update
    void Start()
    {
         recursionRules.Add('X', "F+[[X]-X]-F[-FX]+X");
         recursionRules.Add('F', "FF");
        lineRenderer = new LineRenderer();
        
           GenerateString();
           
       
    }

    public void GenerateString()
    {
        string temp = axiom;
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < iterations; i++) 
        {
            foreach(char c in temp)
            {
                if(recursionRules.ContainsKey(c))
                {
                    sb.Append(recursionRules[c]);
                }
                else
                {
                    sb.Append(c);
                }
            }
            temp=sb.ToString();
            sb = new StringBuilder();
        }
        ApplyRules(temp);
    }

    void ApplyRules(string recursiveString)
    {
        int lineIndex = 0;
        LineRenderer lr = null;

        foreach (char c in recursiveString)
        {
            switch (c)
            {
                case 'X':
                    break;

                case 'F':
                   
                    Vector3 startPos= turtle.transform.position;
                    turtle.transform.Translate(Vector3.up*length);

                    lr = turtle.GetComponent<LineRenderer>();

                    lr.SetPosition(lineIndex, startPos);
                    lr.SetPosition(lineIndex + 1, turtle.transform.position);

                    lr.positionCount += 1;
                    lineIndex++;

                    break;

                case '+':
                    turtle.transform.Rotate(0, 0, Random.Range(angle - 10, angle + 10));
                    break;
                case '-':
                    turtle.transform.Rotate(0, 0, Random.Range(-angle - 10, -angle + 10));
                    break;
                case '[':
                    TransformData transformData = new TransformData();
                    transformData.position = turtle.transform.position;
                    transformData.rotation = turtle.transform.rotation;
                    _transformData.Push(transformData);
                    break;
                case ']':
                    TransformData transformDatas = _transformData.Pop();
                    turtle.transform.position=transformDatas.position;
                    turtle.transform.rotation=transformDatas.rotation;
                    break;
            }             
        }

        lr.positionCount = lr.positionCount - 1;     
    }    

    // Update is called once per frame
    void Update()
    {
       
            //            Vector3 ranPos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            //            Vector3 rot = new Vector3(0, 0, -90);
            //Instantiate(turtle, ranPos, Quaternion.Euler(rot));
            //           // GameObject tree= 
            //            //Poisson.tree = tree;
            //InstantiateTrees();
        if(Input.GetKeyDown(KeyCode.V))
        {
            turtle.SetActive(true);
            InstantiateTrees();
        }
       
            
       
    }
    public void InstantiateTrees()
    {

        // Vector3 ranPos = new Vector3(Random.Range(-TerrainValue.instance.Width, TerrainValue.instance.Height), 0, Random.Range(-TerrainValue.instance.Width, TerrainValue.instance.Height));
      
        Instantiate(turtle, SpawnPos.transform.position, Quaternion.identity);

    }
    
}
