using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<PlayerHealth>();

            if(healthComponent != null)
            {
                healthComponent.takeDamage(1);
            }
        }


    }
}




