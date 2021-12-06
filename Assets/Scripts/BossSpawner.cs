using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    private GameObject queenBee;
    private GameObject queenBeeRoom;

    private GameObject beeActive;
    


    public int boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = Random.Range(0, 4);

        queenBee = GameObject.Find("Queen Bee");

        queenBeeRoom = GameObject.Find("Queen Bee Room");   

        queenBee.SetActive(false);

        queenBeeRoom.SetActive(false);

        GameObject beeActive = GameObject.Find("BeeBossActivation");
        BeeActivation queenBeeScript = queenBee.GetComponent<BeeActivation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (BeeActivation.beeActivation == true && boss == 1)
        {
            
            queenBee.SetActive(true);
            queenBeeRoom.SetActive(true);
            BeeActivation.beeActivation = false;
        }

        else if (gameObject.name == "BeeBossActivation" && boss == 2)
        {
            Debug.Log("Undead Bee");
        }

        else if (gameObject.name == "SlimeBossActivation" && boss == 3)
        {
            Debug.Log("King Slime");
        }
    }



    
}
