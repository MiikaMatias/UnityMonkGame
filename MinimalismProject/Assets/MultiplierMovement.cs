using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierMovement : MonoBehaviour
{
    public float persec = 1;
    private float yconst;

    private float amplitude = 20;
    private float frequency = 30;
    void Start()
    {
        yconst = transform.position.y;

        if(transform.position.x < 0)
        {
            persec = 1;
        }
        else
        {
            persec = -1;
        }
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.position = new Vector3(transform.position.x + persec, amplitude * Mathf.Sin(transform.position.x / frequency) + yconst, transform.position.z);
        }

        amplitude -= Random.Range(-0.01f, 0.01f);
        frequency -= Random.Range(-0.01f, 0.01f);
        persec -= Random.Range(-0.01f, 0.0012f);
    }
}
