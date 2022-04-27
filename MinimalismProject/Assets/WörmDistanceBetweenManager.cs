using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmDistanceBetweenManager : MonoBehaviour
{
    public GameObject child;

    public float maxmag = 100;
    public float minmag = 30;

    public float connectionSpeed = 5;

    private void Update()
    {
        Vector3 magVector = child.transform.position - transform.position;
        if(magVector.magnitude >= maxmag)
        {
            child.transform.position = Vector3.MoveTowards(child.transform.position, transform.position, connectionSpeed*Time.deltaTime);
        }

        if (magVector.magnitude <= minmag)
        {
            child.transform.position = Vector3.MoveTowards(child.transform.position, transform.position, -connectionSpeed * Time.deltaTime);
        }

        maxmag += Random.Range(-1f, 1f);
        minmag += Random.Range(-1f, 1f);
    }
}
