using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        DrawTimer();
    }
    public void DrawTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft <= 0)
        {
            timeLeft = 0;
            SceneManager.LoadScene(1);

        }
        //int minutes = Mathf.FloorToInt(timeLeft / 60);
        //int seconds = Mathf.FloorToInt(timeLeft / 60);
        timerText.text = timeLeft.ToString();
    }
}
