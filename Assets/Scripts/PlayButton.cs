using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject Plane;
    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject Objective1;
    [SerializeField] GameObject Objective2;
    [SerializeField] GameObject Objective3;
    [SerializeField] GameObject Objective4;
    [SerializeField] GameObject Objective5;
    [SerializeField] GameObject Objective6;
    [SerializeField] GameObject Objective7;
    [SerializeField] GameObject Objective8;
    [SerializeField] GameObject Objective9;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerButton()
    {
        Plane.SetActive(true);
        playerCanvas.SetActive(true);
        Objective1.SetActive(true);
        Objective2.SetActive(true);
        Objective3.SetActive(true);
        Objective4.SetActive(true);
        Objective5.SetActive(true);
        Objective6.SetActive(true);
        Objective7.SetActive(true);
        Objective8.SetActive(true);
        Objective9.SetActive(true);
    }
}
