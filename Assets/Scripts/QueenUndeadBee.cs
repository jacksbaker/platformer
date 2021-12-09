using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenUndeadBee : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        //public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float searchCountdown = 1f;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;



    //public int maxHealth = 10;
    public int currentHealth;
    public int damageOutput = 1;

    private GameObject queenUndeadBeeSprite;
    private SpriteRenderer queenUndeadBeeColor;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float stopWatch;

    private ParticleSystem part;

    private GameObject rubber;

    private GameObject queenUndeadBeeActive;

    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {


        GameObject queenBee = GameObject.Find("Queen Bee");
        EnemyAI queenBeeScript = queenBee.GetComponent<EnemyAI>();

        queenUndeadBeeSprite = GameObject.Find("QueenBeeSprite");
        queenUndeadBeeColor = queenUndeadBeeSprite.GetComponent<SpriteRenderer>();

        part = GetComponent<ParticleSystem>();

        rubber = GameObject.Find("QueenBeeRubber");
        rubber.SetActive(false);

        queenUndeadBeeActive = GameObject.Find("Queen Undead Bee");



        currentHealth = 10;
        //currentHealth = maxHealth;



        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountdown = timeBetweenWaves;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    //Debug.Log("No enemies!");
                    WaveCompleted();

                }
                else
                {
                    return;
                }
            }

            if (waveCountdown < -0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            //Debug.Log("No ship");
            if (GameObject.FindGameObjectWithTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<PlayerHealth>();

            if (healthComponent != null)
            {
                healthComponent.takeDamage(damageOutput);
            }
        }


    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //dead 
            Debug.Log("Boss dead");
            queenUndeadBeeActive.SetActive(false);
            rubber.SetActive(true);


        }

        else if (currentHealth <= 6)
        {
            EnemyAI.speed = 450f;
            //queenBeeColor.color = new Color32(248, 216, 216, 255);
            //Shoot();


            if (currentHealth <= 3)
            {
                damage = 2;
                EnemyAI.speed = 800f;
                //queenBeeColor.color = new Color32(200, 162, 162, 255);
                if (!part.isPlaying) part.Play();
            }
        }


    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            //Debug.Log ("ALL WAVES COMPLETED!");
        }
        else
        {
            nextWave++;
        }



    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown < -0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawn Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawing Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);

    }


}


   


