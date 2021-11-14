using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth == 0)
        {
            //dead 
            gameObject.SetActive(false);
        }
    }
}
