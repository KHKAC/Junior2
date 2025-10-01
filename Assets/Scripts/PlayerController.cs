using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float MOVE_LIMIT = 10.0f;
    readonly Vector3 ADJUST_UP = new Vector3(0, 0.5f, 0);

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = MOVE_LIMIT;
    public GameObject projectilePrefab;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right
            * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(
                -xRange,
                transform.position.y,
                transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(
                xRange,
                transform.position.y,
                transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab,
                transform.position + ADJUST_UP,
                projectilePrefab.transform.rotation);
        }
    }
}
