using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    private GameObject queenBee;
    private GameObject queenBeeRoom;

    private GameObject beeActive;

    private GameObject queenUndeadBee;

    private GameObject bossFinderBee;

    public int boss;


    // Start is called before the first frame update
    void Start()
    {
        boss = Random.Range(0, 3);

        queenBee = GameObject.Find("Queen Bee");
        queenUndeadBee = GameObject.Find("Queen Undead Bee");

        queenBeeRoom = GameObject.Find("Queen Bee Room");
        bossFinderBee = GameObject.Find("BeeBossActivation");

        queenBee.SetActive(false);
        queenUndeadBee.SetActive(false);

        queenBeeRoom.SetActive(false);

        bossFinderBee.SetActive(true);

        GameObject beeActive = GameObject.Find("BeeBossActivation");
        BeeActivation queenBeeScript = queenBee.GetComponent<BeeActivation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (BeeActivation.beeActivation == true && boss == 0)
        {
            
            queenBee.SetActive(true);
            queenBeeRoom.SetActive(true);
            BeeActivation.beeActivation = false;
            bossFinderBee.SetActive(false);
        }

        else if (BeeActivation.beeActivation && boss == 1)
        {
            queenUndeadBee.SetActive(true);
            queenBeeRoom.SetActive(true);
            BeeActivation.beeActivation = false;
            bossFinderBee.SetActive(false);
        }

        else if (gameObject.name == "SlimeBossActivation" && boss == 2)
        {
            Debug.Log("King Slime");
        }
    }



    
}
