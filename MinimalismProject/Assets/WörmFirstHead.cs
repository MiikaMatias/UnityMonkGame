using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmFirstHead : MonoBehaviour
{
    [SerializeField] private GameObject wörmBody;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject child;

    Vector3 toward;

    public float instantiateDistance = 50;

    private void Start()
    {
        findObjects();
        getToward();
        instantiateHead();
        setAsParent();
    }

    private void findObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void getToward()
    {
        toward = player.transform.position - transform.position;
    }
    private void instantiateHead()
    {
        child = Instantiate(wörmBody, transform.position + toward * instantiateDistance, Quaternion.identity);
    }



    
    private void setAsParent()
    {
        child.transform.parent = gameObject.transform;
        child.GetComponent<WörmMultiply>().firstWörm = gameObject;
    }
}
