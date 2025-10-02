using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    const float WAIT_TIME = 2.0f;
    public GameObject dogPrefab;
    float timer = WAIT_TIME;
    bool isGameOver = false;

    void OnEnable()
    {
        DestroyOutOfBoundsX.OnGameOver += SetGameOver;
    }

    void OnDisable()
    {
        DestroyOutOfBoundsX.OnGameOver -= SetGameOver;
    }

    void Update()
    {
        if (isGameOver) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = WAIT_TIME;
            }
        }
    }

    void SetGameOver()
    {
        isGameOver = true;
    }
}
