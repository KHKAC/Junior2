using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    [SerializeField] GameObject gameOverPanel;
    float spawnRangeX = 20.0f;
    float spawnPosZ = 20.0f;
    float startDelay = 2.0f;
    float spawnInterval = 1.5f;

    void OnEnable()
    {
        DestroyOutOfBounds.OnGameOver += DisplayGameOver;
    }

    void OnDisable()
    {
        DestroyOutOfBounds.OnGameOver -= DisplayGameOver;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    public void DisplayGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
