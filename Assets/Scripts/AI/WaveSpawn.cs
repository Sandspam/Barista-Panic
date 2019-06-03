using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    public int waves;
    public float timeBetweenSpawn;
    public GameObject[] enemies;
    public float timeBeforeEnd;
    public Transform[] spawnPoints;
    private float spawnTimer;
    private int enemiesToSpawn;
    private int enemiesRemaining;
    private int wavesRemaining;
    [HideInInspector] public float endTimer;
    public bool tutorial;

    // Use this for initialization
    void Start ()
    {
        spawnPoints[0] = GameObject.Find("Spawn1").transform;
        spawnPoints[1] = GameObject.Find("Spawn2").transform;
        spawnPoints[2] = GameObject.Find("Spawn3").transform;
        spawnPoints[3] = GameObject.Find("Spawn4").transform;
        spawnTimer = timeBetweenSpawn;
        wavesRemaining = waves;
        endTimer = timeBeforeEnd;
        Time.timeScale = 1f;
        if(DataHolder.Kultists <= 25)
        {
            spawnTimer = 0.1f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        endTimer -= Time.deltaTime;

        if (endTimer >= 1)
            StartWave();

        if (endTimer <= 0)
            EndGame(false);

        GameObject.Find("NightTimeKeeper").GetComponent<Text>().text = "Time remaining: " + endTimer.ToString("N0");
    }

    void StartWave ()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            int enemyNumber = Random.Range(0, enemies.Length);
            if (enemies[enemyNumber].name == "KultistNight" && DataHolder.KultistsAtNight <= 0)
            {
                enemyNumber = Random.Range(0, enemies.Length - 1);
            }
            int spawnNumber = Random.Range(0, spawnPoints.Length);
            GameObject instance = Instantiate(enemies[enemyNumber], spawnPoints[spawnNumber].position, Quaternion.identity);
            if(enemies[enemyNumber].name == "Beanliner")
            {
                if (spawnNumber == 0)
                {
                    instance.GetComponentInChildren<BeanlinerController>().Warn(new Vector3(8.38f, 9.4f));
                }

                if (spawnNumber == 1)
                {
                    instance.GetComponentInChildren<BeanlinerController>().Warn(new Vector3(8.38f, 4.94f));
                }

                if (spawnNumber == 2)
                {
                    instance.GetComponentInChildren<BeanlinerController>().Warn(new Vector3(8.21f, -1.06f));
                }

                if (spawnNumber == 3)
                {
                    instance.GetComponentInChildren<BeanlinerController>().Warn(new Vector3(8.38f, -3.71f));
                }
            }
            spawnTimer = timeBetweenSpawn;
        }
    }

    public void EndGame (bool playerDied)
    {
        Time.timeScale = 0f;
        if (playerDied)
        {
            GameObject.Find("Canvas").gameObject.transform.GetChild(1).gameObject.SetActive(true);
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < gameObjects.Length; i++)
                Destroy(gameObjects[i].transform.parent);

            Destroy(GameObject.Find("Player"));
        }

        if (!playerDied)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < gameObjects.Length; i++)
                Destroy(gameObjects[i].transform.parent);

            Destroy(GameObject.Find("Player"));
            GameObject.Find("Canvas").gameObject.transform.GetChild(2).gameObject.SetActive(true);
            if (tutorial)
            {
                GameObject.Find("EndNightDialogue").GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

        if(tutorial)
        {
            DataHolder.Coins = 0;
            DataHolder.ArmorTier = 0;
            DataHolder.SpeedTier = 0;
            DataHolder.HPFillTier = 0;
            DataHolder.RifleTier = 0;
            DataHolder.ShotgunTier = 0;
            DataHolder.GrenadeTier = 0;
            DataHolder.RapidFireTier = 0;
            DataHolder.ShieldTier = 0;
            DataHolder.PetHealTier = 0;
            DataHolder.PetDamageTier = 0;
            DataHolder.PetSpeedTier = 0;
            DataHolder.PetMaxHealthTier = 0;
        }
    }
}
