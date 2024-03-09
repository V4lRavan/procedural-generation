using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Target : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Player.score += 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
