using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float throttleChange = 0.1f;
    public float fullPower = 200f;
    //public float levelOfControl = 10f;
    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    [SerializeField] Transform orientation;
   

    public float liftForce = 135f;

    public static int score = 0;
    TextMeshProUGUI UIscore;
    private float tweakResponse
    {
        get
        {
            return (rb.mass / 10f) * throttleChange;
        }
    }
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Inputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleChange;
        else if(Input.GetKey(KeyCode.LeftControl))throttle-= throttleChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        UIscore=GetComponent<TextMeshProUGUI>();
       
    }

    void DrawScore()
    {
        UIscore.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        DrawScore();
        WinCondition();
    }

    private void FixedUpdate()
    {
        rb.AddForce(orientation.transform.forward * fullPower * throttle);
        rb.AddTorque(orientation.transform.up * yaw * tweakResponse);
        rb.AddTorque(orientation.transform.right * pitch * tweakResponse);
        rb.AddTorque(-orientation.transform.forward * roll * tweakResponse);

        rb.AddForce(Vector3.up * rb.velocity.magnitude * liftForce);
    }

    void WinCondition()
    {
        if(score>=900)
        {
            SceneManager.LoadScene(2);
        }
    }

    
}
