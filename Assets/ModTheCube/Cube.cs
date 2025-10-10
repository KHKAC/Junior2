using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float changeInterval = 3.0f;
    private float timer = 0.0f;

    private float rotationSpeed = 10.0f;

    private Material material;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        float newScale = Random.Range(0.5f, 5.0f);
        transform.localScale = Vector3.one * newScale;
        rotationSpeed = Random.Range(5.0f, 1000.0f);

        material = Renderer.material;
        material.color = new Color(Random.value, Random.value, Random.value, Random.Range(0.3f, 1.0f));
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);

        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            ChangeProperties();
            timer = 0.0f;
        }
    }

    void ChangeProperties()
    {
        float newScale = Random.Range(0.5f, 2.0f);
        transform.localScale = Vector3.one * newScale;
        rotationSpeed = Random.Range(5.0f, 1000.0f);

        Color newColor = new Color(Random.value, Random.value, Random.value, Random.Range(0.3f, 1.0f));
        material.color = newColor;

        float newX = Random.Range(-5f, 5f);
        float newY = Random.Range(-5f, 5f);
        float newZ = Random.Range(-5f, 5f);
        transform.position = new Vector3(newX, newY, newZ);

        float rotX = Random.Range(0f, 360f);
        float rotY = Random.Range(0f, 360f);
        float rotZ = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}
