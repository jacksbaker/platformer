using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeBuffs : MonoBehaviour
{
    private BoxCollider2D coll;

    public float stopWatch;

    public bool buffActive;



    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();

        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovment playerScript = thePlayer.GetComponent<PlayerMovment>();



        stopWatch = 0f;

        buffActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        stopWatch = stopWatch - Time.deltaTime;


        if (stopWatch <= 0)
        {
            //Debug.Log("NoBuff");
            buffActive = false;

            PlayerMovment.slowness = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player" && gameObject.tag == "Slowness" && buffActive == !true)
        {
            stopWatch = 8f;

            Debug.Log("Slowness");

            buffActive = true;
            
            PlayerMovment.slowness = true;


        }

    }
}