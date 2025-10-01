using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 3. Unity Event 이용
public class GameOverAction : UnityEngine.Events.UnityEvent { }
public class DestroyOutOfBounds : MonoBehaviour
{
    // 1. SpawnManager를 정의해서 태그 찾아 연결
    // SpawnManager sm;
    // 2. delegate 이용;
    // public delegate void GameOverHandler();
    // public static event GameOverHandler OnGameOver;

    // 3.
    public static GameOverAction OnGameOver = new GameOverAction();

    float topBound = 30.0f;
    float lowerBound = -10.0f;

    void Start()
    {
        //SpawnManager 연결 1(SpawnManager sm;)
        //sm = GameObject.FindGameObjectWithTag("SM").GetComponent<SpawnManager>();
    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            //SpawnManager의 DisplayGameOver 호출
            //sm.DisplayGameOver();
            // 2.
            // OnGameOver();
            OnGameOver.Invoke();
            Destroy(gameObject);
        }
        // if (transform.position.z > topBound ||
        //     transform.position.z < lowerBound)
        // {
        //     Destroy(gameObject);
        // }
    }
}
