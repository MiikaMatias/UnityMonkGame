using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpeedControl : MonoBehaviour
{

    static public float speed = 1;
    void Start()
    {
        StartCoroutine(tentacleSpeed());
    }

    IEnumerator tentacleSpeed()
    {
        yield return new WaitForSeconds(Random.Range(1,4));
        if (TentacleSpeedControl.speed < 0)
        {
            speed = Random.Range(0, 0.1f);
        }
        else
        {
            speed = Random.Range(-0.1f, 0);
        }
        StartCoroutine(tentacleSpeed());
    }
}
