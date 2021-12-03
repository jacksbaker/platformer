using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenMovement : MonoBehaviour
{
    [SerializeField] private float dirX = 1f;
    static public float moveSpeed = 1f;
    Animator animator; 

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.x);
        animator.SetBool("IsRunning", true); 
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.x);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Righty")
        {
            dirX = -1f;
            moveSpeed++;
        }

        else if (collision.tag == "Lefty")
        {
            dirX = 1f;
            moveSpeed++;
        }
    }

}
