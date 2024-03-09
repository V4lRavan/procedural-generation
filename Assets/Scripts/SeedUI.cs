using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SeedText;
    // Start is called before the first frame update
    void Start()
    {
        SeedText=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSeed();
    }
    public void SetSeed()
    {
        SeedText.text = "Seed= " + TerrainValue.instance.seed.ToString();
    }
}
