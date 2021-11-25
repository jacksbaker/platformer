using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    public float stopWatch;
    public bool Day;

    public GameObject dayBackground;
    public GameObject nightBackground;
    public GameObject bats;

    

    //public GameObject[] bats;



    // Start is called before the first frame update
    void Start()
    {

        dayBackground = GameObject.Find("Day");
        nightBackground = GameObject.Find("Night");
        bats = GameObject.Find("Bats");


        //bat = GameObject.FindGameObjectsWithTag("Bat");
        //dayBackground.SetActive(true);
        //nightBackground.SetActive(false);

        Day = true;
        stopWatch = 0f;
        

        //GameObject.FindGameObjectWithTag("Bats").SetActive(false);

        //bats = GameObject.FindGameObjectsWithTag("myTag");
        //stopWatch = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        stopWatch = stopWatch - Time.deltaTime;

        if (stopWatch <= 0 && Day == true)
        {

            Debug.Log("Day");
           

            dayBackground.SetActive(true);

            nightBackground.SetActive(false);

            bats.SetActive(false);

            //GameObject.FindGameObjectWithTag("Bats").SetActive(false);

            Day = false;
            stopWatch = 20f;
        }

        else if (stopWatch <= 0 && Day == false)
        {
            Debug.Log("Night");
            dayBackground.SetActive(false);

            nightBackground.SetActive(true);

            bats.SetActive(true);

            //.FindGameObjectWithTag("Bats").SetActive(true);

            Day = true;
            stopWatch = 20f;
        }
    }
}
