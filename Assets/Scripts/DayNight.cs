using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DayNight : MonoBehaviour
{

    public float stopWatch;
    public bool Day;

    private GameObject dayBackground;
    private GameObject nightBackground;
    private GameObject bats;
    private GameObject platforms;
    private GameObject thePlayer;
    private GameObject fallThrough;
    private GameObject vine;
    private GameObject tress;
    private GameObject objects;
    private GameObject destroyablePlatforms;
    //private GameObject [] vine;

    private Tilemap platform;
    private SpriteRenderer player;
    private Tilemap fallThroughPlatform;
    private Tilemap trees;
    private Tilemap objectColour;
    private Tilemap destroyablePlatform;
    //private Renderer vines;




    //public GameObject[] bats;



    // Start is called before the first frame update
    void Start()
    {

        dayBackground = GameObject.Find("Day");
        nightBackground = GameObject.Find("Night");
        bats = GameObject.Find("Bats");
        platforms = GameObject.Find("Platforms");
        thePlayer = GameObject.Find("Player");
        fallThrough = GameObject.Find("Fall through platforms");
        vine = GameObject.Find("Vines");
        tress = GameObject.Find("Tress");
        objects = GameObject.Find("Objects");
        destroyablePlatforms = GameObject.Find("Destroyable platform");
        //vine = GameObject.FindGameObjectsWithTag("VineSprites");




        platform = platforms.GetComponent<Tilemap>();
        player = thePlayer.GetComponent<SpriteRenderer>();
        fallThroughPlatform = fallThrough.GetComponent<Tilemap>();
        trees = tress.GetComponent<Tilemap>();
        objectColour = objects.GetComponent<Tilemap>();
        destroyablePlatform = destroyablePlatforms.GetComponent<Tilemap>();


        //GetComponent<SpriteRenderer>().color = Color.green;



        //bat = GameObject.FindGameObjectsWithTag("Bat");
        //dayBackground.SetActive(true);
        //nightBackground.SetActive(false);

        Day = true;
        stopWatch = 0f;
        

        //GameObject.FindGameObjectWithTag("Bats").SetActive(false);

        //bats = GameObject.FindGameObjectsWithTag("myTag");
        //stopWatch = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        stopWatch = stopWatch - Time.deltaTime;

        if (stopWatch <= 0 && Day == true)
        {

            Debug.Log("Day");
           

            dayBackground.SetActive(true);

            nightBackground.SetActive(false);

            bats.SetActive(false);

            vine.SetActive(true);

            platform.color = new Color32(255, 255, 255, 255);
            player.color = new Color32(255, 255, 255, 255);
            fallThroughPlatform.color = new Color32(255, 255, 255, 255);
            trees.color = new Color32(255, 255, 255, 255);
            objectColour.color = new Color(255, 255, 255, 255);
            destroyablePlatform.color = new Color32(255, 255, 255, 255);

            //GameObject.FindGameObjectWithTag("Bats").SetActive(false);

            Day = false;
            stopWatch = 20f;
        }

        else if (stopWatch <= 0 && Day == false)
        {
            Debug.Log("Night");
            dayBackground.SetActive(false);

            nightBackground.SetActive(true);

            bats.SetActive(true);

            vine.SetActive(false);



            platform.color = new Color32(161, 159, 159, 255);
            player.color = new Color32(161, 159, 159, 255);
            fallThroughPlatform.color = new Color32(161, 159, 159, 255);
            trees.color = new Color32(161, 159, 159, 255);
            objectColour.color = new Color(161, 159, 159, 255);
            destroyablePlatform.color = new Color32(161, 159, 159, 255);

            //.FindGameObjectWithTag("Bats").SetActive(true);

            Day = true;
            stopWatch = 20f;
        }
    }
}
