using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingSlime : MonoBehaviour
{  
    
    //public int maxHealth = 10;
    public int currentHealth;
    public int damageOutput = 1;

    private GameObject kingSlimeSprite;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float stopWatch;

    private ParticleSystem part;

    private GameObject rubber;

    private GameObject kingSlimeActive;


    // Start is called before the first frame update
    void Start()
    {


        GameObject queenBee = GameObject.Find("King Slime");
        EnemyAI queenBeeScript = queenBee.GetComponent<EnemyAI>();

        kingSlimeSprite = GameObject.Find("KingSlimeSprite");
       

        part = GetComponent<ParticleSystem>();

        rubber = GameObject.Find("KingSlimeRubber");
        rubber.SetActive(false);

        kingSlimeActive = GameObject.Find("King Slime");



        currentHealth = 10;
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<PlayerHealth>();

            if (healthComponent != null)
            {
                healthComponent.takeDamage(damageOutput);
            }
        }


    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //dead 
            Debug.Log("Boss dead");
            kingSlimeActive.SetActive(false);
            rubber.SetActive(true);


        }

        else if (currentHealth <= 6)
        {
            EnemyAI.speed = 450f;
         
            //Shoot();


            if (currentHealth <= 3)
            {
                damage = 5;
              
            }
        }


    }

    void Shoot()
    {
        //shooting logic 

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}

