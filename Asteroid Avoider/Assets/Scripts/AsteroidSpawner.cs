using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private Camera mainCamera;

    private float timer;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update() 
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnAsteroid();

            timer += secondsBetweenAsteroids;
        }    
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0: //Left side
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1: // Right side
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2: // Bottom side
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3: // Top side
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0f;
        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        

        GameObject asteroidInstance = Instantiate(selectedAsteroid, 
                                                worldSpawnPoint, 
                                                Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody asteroidRigidBody = asteroidInstance.GetComponent<Rigidbody>();
        asteroidRigidBody.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
   }
}
