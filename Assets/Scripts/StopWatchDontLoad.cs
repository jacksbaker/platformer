using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchDontLoad : MonoBehaviour
{

    public bool stopwatchExists;
    // Start is called before the first frame update
    void Start()
    {
        if (!stopwatchExists)
        {
            stopwatchExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
