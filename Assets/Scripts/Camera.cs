using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Camera : MonoBehaviour
{
    [SerializeField] Camera camera;
    CameraSwitcher CameraSwitcher;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    void DisableCamera()
    {
        camera.enabled = false;
        //CameraSwitcher.
        //CameraSwitcher.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
