using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{

    float timer;
    float seconds;
    float minutes;
    float hours;

    public bool start;

    public bool stopwatchActive;

    private bool stopwatchExists;

    [SerializeField] Text stopWatchText;
    // Start is called before the first frame update
    void Start()
    {
        stopwatchActive = false;
        start = true;
        timer = 0;

        //DontDestroyOnLoad(transform.gameObject);

        //if (!stopwatchExists)
        //{
        //    stopwatchExists = true;
        //    DontDestroyOnLoad(transform.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);


        //}
    }

    // Update is called once per frame
    void Update()
    {
        StopWatchCalcul();
    }

    void StopWatchCalcul()
    {
        if (start == true)
        {
            stopwatchActive = true;
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
            minutes = (int)(timer / 60) % 60;
            hours = (int)(timer / 3600);

            stopWatchText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");

        }


    }

    
}
