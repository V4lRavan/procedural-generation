using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Poisson.instance=Poisson.instance.GetComponent<Poisson>();
    }

    // Update is called once per frame
    void Update()
    {
        PoissonButton();
    }
    public void PoissonButton()
    {
        Poisson.instance.Generate();
    }
}
