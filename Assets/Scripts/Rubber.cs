using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{

    public bool playerRubber;
    private bool rubberActive;
    public GameObject theRubber;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        //playerRubber = false;
        rubberActive = true;

        theRubber = GameObject.Find("RubberSprite");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && rubberActive == true && gameObject.tag == ("Rubber"))
        {
            Debug.Log("Player");
            playerRubber = true;
            theRubber.SetActive(false);
            rubberActive = false;

        }
        /*
        else if(collision.tag == "Player" && playerRubber == true && gameObject.tag == ("DestroyablePlatform"))
        {
            Debug.Log("Destroy");
            gameObject.SetActive(false);
        }
    }
        */





    }
}
