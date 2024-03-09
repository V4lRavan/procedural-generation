using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Menu : MonoBehaviour
{
   
    // Start is called before the first frame update

    void Start()
    {
       
;
    }
    public void SizeMenu(TMP_Dropdown tMP_Dropdown)
    {
        int desiredSize;
        if (tMP_Dropdown.value == 0) 
        {
            desiredSize = 241;
           //TerrainValue.instance.factorValue = 2;
            TerrainValue.instance.SetHeight(desiredSize);
            TerrainValue.instance.SetWidth(desiredSize);
        }
        else if(tMP_Dropdown.value==1)
        {
            desiredSize = 121;
            //TerrainValue.instance.factorValue = 2;
            TerrainValue.instance.SetHeight(desiredSize);
            TerrainValue.instance.SetWidth(desiredSize);
        }
        else if( tMP_Dropdown.value==2) 
        {
            desiredSize = 61;
            TerrainValue.instance.SetHeight(desiredSize);
            TerrainValue.instance.SetWidth(desiredSize);
        }
        UpdateValues(tMP_Dropdown);
    }

    public void CollisionLODMenu(TMP_Dropdown tMP_Dropdown) 
    {
        if (tMP_Dropdown.value == 0)
        {
            TerrainValue.instance.collisionFactor = 1;

        }
        else if(tMP_Dropdown.value==1)
        {
            TerrainValue.instance.collisionFactor = 2;

        }
        else if(tMP_Dropdown.value==2)
        {
            TerrainValue.instance.collisionFactor = 4;

        }
       
    }

    public void MeshLODMenu(TMP_Dropdown tMP_Dropdown)
    {
        if (tMP_Dropdown.value == 0)
        {
            
            TerrainValue.instance.SetFactor(1);
        }
        else if (tMP_Dropdown.value == 1)
        {
            
            TerrainValue.instance.SetFactor(2);
        }
        else if (tMP_Dropdown.value == 2)
        {
            
            TerrainValue.instance.SetFactor(4);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateValues(TMP_Dropdown dropdown)
    {

    }

    public void SetScale()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //float f = slider.value = p.GetScale();
        }
        //scaleText.text = p.GetScale().ToString();
    }
    public void ScaleApply()
    {
        //PlayerPrefs.SetFloat("wow", p.GetScale());
    }
}
