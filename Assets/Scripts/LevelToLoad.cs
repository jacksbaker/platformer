using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToLoad : MonoBehaviour
{
    public string levelToLoad;

    public string exitPoint;

    private PlayerMovment thePlayer;

    public string Test { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitPoint;

            if(GameObject.Find("Stopwatch").GetComponent<StopWatch>().stopwatchActive == true)
            {
                GameObject.Find("Stopwatch").GetComponent<StopWatch>().start = false;
            }
        }
    }
}
