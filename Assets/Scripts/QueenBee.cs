using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBee : MonoBehaviour
{

    //public int maxHealth = 10;
    public int currentHealth;
    public int damageOutput = 1;

    private GameObject queenBeeSprite;
    private SpriteRenderer queenBeeColor;

    private ParticleSystem part;

    public GameObject rubber;

    private GameObject queenBeeActive;

    private GameObject queenBeeRoom;


    // Start is called before the first frame update
    void Start()
    {


        GameObject queenBee = GameObject.Find("Queen Bee");
        queenBeeActive = GameObject.Find("Queen Bee");
        EnemyAI queenBeeScript  = queenBee.GetComponent<EnemyAI>();

        queenBeeSprite = GameObject.Find("QueenBeeSprite");
        queenBeeColor = queenBeeSprite.GetComponent<SpriteRenderer>();

        part = GetComponent<ParticleSystem>();

        queenBeeRoom = GameObject.Find("Queen Bee Room");

        //rubber = GameObject.Find("QueenBeeRubber");
        //rubber.SetActive(false);





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
            queenBeeActive.SetActive(false);
            rubber.SetActive(true);
            queenBeeRoom.SetActive(false);


        }

        else if (currentHealth <= 6)
        {
            EnemyAI.speed = 450f;
            queenBeeColor.color = new Color32(248, 216, 216, 255);
            //Shoot();


            if (currentHealth <= 3)
            {
                damage = 2;
                EnemyAI.speed = 800f;
                queenBeeColor.color = new Color32(200, 162, 162, 255);
                if (!part.isPlaying) part.Play();
            }
        }

        
    }

 
}
