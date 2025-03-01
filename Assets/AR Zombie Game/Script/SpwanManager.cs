using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public static SpwanManager instance;
    public bool isSpwan;
    [SerializeField] GameObject enemyPrefeb;
    [SerializeField] float spawnInterval = 5f;
    private float spawnTimer = 0f;
    


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isSpwan = false;
    }



    void Update()
    {
        if (isSpwan)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }
    public void SpawnEnemy()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;

            float randomx = Random.Range(-1f, 1f);
            float randomz = Random.Range(-1f, 1f);

            Vector3 spwanPos = new Vector3(playerPos.x + randomx, 0, playerPos.z + randomz);

            Instantiate(enemyPrefeb,spwanPos, Quaternion.identity);

        }
        
    }


    // Tried without conditions like isspawn;

}

