using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    private GameObject queenBee;
    private GameObject queenBeeRoom;

    private GameObject beeActive;

    private GameObject queenUndeadBee;
    private GameObject kingSlime;
    private GameObject slimeRoom;
    private GameObject slimeActive;
    private GameObject slimeFinder;


    private GameObject bossFinderBee;

    public int boss;


    // Start is called before the first frame update
    void Start()
    {
        boss = Random.Range(0, 3);

        queenBee = GameObject.Find("Queen Bee");
        queenUndeadBee = GameObject.Find("Queen Undead Bee");
        kingSlime = GameObject.Find("KingSlime");

        queenBeeRoom = GameObject.Find("Queen Bee Room");
        bossFinderBee = GameObject.Find("BeeBossActivation");
        slimeFinder = GameObject.Find("KingSlimeActivation");
        slimeRoom = GameObject.Find("King Slime Room");
        

        queenBee.SetActive(false);
        queenUndeadBee.SetActive(false);

        queenBeeRoom.SetActive(false);

        bossFinderBee.SetActive(true);

        kingSlime.SetActive(false);

        slimeFinder.SetActive(true);

        slimeRoom.SetActive(false);

        GameObject beeActive = GameObject.Find("BeeBossActivation");
        BeeActivation queenBeeScript = queenBee.GetComponent<BeeActivation>();

        GameObject slimeActive = GameObject.Find("KingSlimeActivation");
        SlimeActivation kingSlimeScript = slimeFinder.GetComponent<SlimeActivation>();
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

        else if (BeeActivation.beeActivation == true && boss == 1)
        {
            queenUndeadBee.SetActive(true);
            queenBeeRoom.SetActive(true);
            BeeActivation.beeActivation = false;
            bossFinderBee.SetActive(false);
        }

        else if (SlimeActivation.slimeActivation == true && boss == 2)
        {
            SlimeActivation.slimeActivation = false;
            kingSlime.SetActive(true);
            slimeFinder.SetActive(false);
            slimeRoom.SetActive(true);
        }
    }



    
}
