using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmMultiply : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Circle;
    [SerializeField] private GameObject ShootPoint;

    [SerializeField] private GameObject wörm;

    [SerializeField] private GameObject next;

    Vector3 WörmToPlayer;
    Vector3 WörmToRandom;

    private bool permissionToMultiply = false;
    

    private void Start()
    {
        StartCoroutine(checkForPermission());
        Player = GameObject.FindGameObjectWithTag("Player");
        Circle = GameObject.FindGameObjectWithTag("Circle");
        ShootPoint = GameObject.FindGameObjectWithTag("ShootPoint");
    }

    private void Update()
    {
        WörmToPlayer = (transform.position + Player.transform.position);
    }





    IEnumerator checkForPermission()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 circleToShootpoint = (Circle.transform.position + ShootPoint.transform.position);
        Vector3 circleToGameObject = (Circle.transform.position + transform.position);
        if (Vector3.Dot(circleToShootpoint, circleToGameObject) > 0.8f)
        {
            RandomizeVector();
        }

        if(next == null)
        {
            StartCoroutine(checkForPermission());
        }
       
    }

    void RandomizeVector()
    {
        if (next == null)
        {
            WörmToRandom = FindInstantiateVector();
            float dotproduct = Vector3.Dot(WörmToRandom.normalized, WörmToPlayer.normalized);
            print(dotproduct);
            if (dotproduct >= 0.8)
            {
                instantiateWörmHead();
            }
            else
            {
                RandomizeVector();
            }
        }
    }

    void instantiateWörmHead()
    {
        next = Instantiate(wörm, transform.position + WörmToRandom * -70, Quaternion.identity);
    }

    private Vector3 FindInstantiateVector()
    {
        return (transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), transform.position.z)).normalized;
    }
}
