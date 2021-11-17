using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private BoxCollider2D coll;

    public float stopWatch;

    static public bool buffActive;

    //private GameObject particles;

    //public ParticleSystem speedBuffParticles;

   // private GameObject gameObjectFound;
    //public bool speedBuff;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();



        //gameObjectFound = GameObject.Find("Player");
        //ParticleSystem particles = gameObjectFound.GetComponent<ParticleSystem>();

        GameObject thePlayer = GameObject.Find("Player");
        PlayerMovment playerScript = thePlayer.GetComponent<PlayerMovment>();

        GameObject SlownessBuff = GameObject.Find("Slowness");
        DeBuffs speed = SlownessBuff.GetComponent<DeBuffs>();

        //speedBuffParticles = GetComponent<ParticleSystem>();

        stopWatch = 0f;

        buffActive = DeBuffs.buffActiveDeBuff;
        //speedBuff = false;
    }

    // Update is called once per frame
    void Update()
    {
        stopWatch = stopWatch - Time.deltaTime;


        if (stopWatch <= 0)
        {
            //Debug.Log("NoBuff");
            buffActive = false;

            PlayerMovment.speedBuff = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player" && gameObject.tag == "Speed" && buffActive == !true)
        {
            stopWatch = 8f;
            //speedBuff = true;
            Debug.Log("Speed");

            buffActive = true;

            PlayerMovment.speedBuff = true;

            //particles.Play();

            //speedBuffParticles.Play();

        }

        
         
    
       
    }

}
