using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;


    //Variables para limitar la escena
    private float spawnRangeX;
    private float spawnRangeZ;

    private float spawnPosZ;
    private float spawnPosX;
    //Variables para limitar la aparicion de animales.
    private float startDelay;
    private float spawnInterval;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnRangeX = 20.0f;
        spawnRangeZ = 15.0f;
        spawnPosZ = 20.0f;
        spawnPosX = 27.0f;
        startDelay = 2.0f;
        spawnInterval = 5.0f;

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalFromLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalFromRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        /* Hace aparecer animales en una posicion X al azar. */
        int animalIndex = Random.Range(0, this.animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalFromLeft()
    {
        int animalIndex = Random.Range(0, this.animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.FromToRotation(Vector3.forward, Vector3.right));
    }

    void SpawnRandomAnimalFromRight()
    {
        int animalIndex = Random.Range(0, this.animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.FromToRotation(Vector3.forward, Vector3.left));
    }
}
