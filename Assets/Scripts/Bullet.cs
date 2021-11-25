using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        if (hitInfo.tag == "Enemy" || hitInfo.tag == "Bats")
        {
            var healthComponent = hitInfo.GetComponent<EnemyHealth>();

            if (healthComponent != null)
            {
                healthComponent.takeDamage(1);
            }
        }


        Destroy(gameObject);


    }
}
