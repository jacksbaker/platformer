using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;

    public Animator anim;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {

            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }

            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetBool("damageTaken", true);

        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            //dead 
            gameObject.SetActive(false);
        }
    }
}
