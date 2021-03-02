using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger1 : MonoBehaviour
{

    public GameObject[] backgroundObjectsPrefabs;
    public GameObject[] particlesPrefabs;
    public GameObject coinPrefab;
    public GameObject magnetPrefab;
    public GameObject enemyPrefab;
    public GameObject InvisibilityPrefab;

    private float startDelay = 10;

    private PlayerController playerControllerScript;
    private GameManager gameManger;

    void Start()
    {
        playerControllerScript = GameObject.Find("Falcon9").GetComponent<PlayerController>();
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnBackGroundObjects", startDelay, 1f);
        InvokeRepeating("SpawnCoins", startDelay, 1f);

    }

    public void InvokeGoodAndBadObjects(float goodObjectsInvokeRate, float badObjectsInvokeRate)
    {
        InvokeRepeating("SpawnInvisiblityPowerBall", startDelay, goodObjectsInvokeRate);
        InvokeRepeating("SpawnMagnet", startDelay, goodObjectsInvokeRate);

        InvokeRepeating("SpawnEnemies", startDelay, badObjectsInvokeRate);
        InvokeRepeating("SpawnParticles", startDelay, badObjectsInvokeRate);
    }



    private Vector3 RandomSpawnPosition()
    {
        float xRandomPosition = Random.Range(-70, 70);
        float yRandomPosition = Random.Range(-70, 70);

        return new Vector3(xRandomPosition, yRandomPosition, 200);
    }

    void SpawnBackGroundObjects()
    {
        if (gameManger.isGameActive == true)
        {
            int index = Random.Range(0, 6);
            Instantiate(backgroundObjectsPrefabs[index], RandomSpawnPosition(), backgroundObjectsPrefabs[index].transform.rotation);
        }
    }

    void SpawnParticles()
    {
        if (gameManger.isGameActive == true)
        {
            int index = Random.Range(0, 2);
            Instantiate(particlesPrefabs[index], RandomSpawnPosition(), particlesPrefabs[index].transform.rotation);

        }
    }

    void SpawnCoins()
    {
        if (gameManger.isGameActive == true)
        {
            for (int i = 0; i <= 10; i++)
            {
                Instantiate(coinPrefab, RandomSpawnPosition(), coinPrefab.transform.rotation);
            }

        }
    }

    void SpawnMagnet()
    {
        if (gameManger.isGameActive == true)
        {

            Instantiate(magnetPrefab, RandomSpawnPosition(), magnetPrefab.transform.rotation);

        }
    }

    void SpawnEnemies()
    {
        if (gameManger.isGameActive == true)
        {

            Instantiate(enemyPrefab, RandomSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }


    void SpawnInvisiblityPowerBall()
    {
        if (gameManger.isGameActive == true)
        {

            Instantiate(InvisibilityPrefab, RandomSpawnPosition(), InvisibilityPrefab.transform.rotation);

        }
    }

}