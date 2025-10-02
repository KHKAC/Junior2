using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f;
    float spawnIntervalStart = 4.0f;
    float spawnIntervalEnd = 4.0f;

    float timer;

    bool isGameOver;

    void OnEnable()
    {
        DestroyOutOfBoundsX.OnGameOver += DisplayGameOver;
    }

    void OnDisable()
    {
        DestroyOutOfBoundsX.OnGameOver -= DisplayGameOver;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        isGameOver = false;
        timer = startDelay;
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    void Update()
    {
        if (isGameOver) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Invoke("SpawnRandomBall", 0);
            timer = Random.Range(spawnIntervalStart, spawnIntervalEnd);
        }

    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int i = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);
    }


    public void DisplayGameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }

}
