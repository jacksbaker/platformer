
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveablePlatforms : MonoBehaviour
{


    private bool playerHasRubber;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject theRubber = GameObject.Find("Rubber");
        //Rubber rubberScript = theRubber.GetComponent<Rubber>();


    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hi");

        if (collision.tag == "Player" && gameObject.tag == "DestroyablePlatform" && GameObject.Find("QueenBeeRubber").GetComponent<Rubber>().playerRubber == true || GameObject.Find("KingSlimeRubber").GetComponent<Rubber>().playerRubber == true)
        {
            Debug.Log("Destroy");
            gameObject.SetActive(false);
        }
    }
}
