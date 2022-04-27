using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleInstantiateHead : MonoBehaviour
{
    [SerializeField] private GameObject tentacleHead;
    [SerializeField] private GameObject player;

    private bool xBigger = default;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(headInst());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    IEnumerator headInst()
    {
        yield return new WaitForSeconds(1);

        Vector2 toward = default;

        int r = Random.Range(0, 2);
        if(r == 0)
        {
            xBigger = false;
        }
        else
        {
            xBigger = true;
        }

        GameObject x = Instantiate(tentacleHead, transform.position, Quaternion.identity);
        x.transform.parent = gameObject.transform;
        x.GetComponent<TentacleHeadInstantiateAnother>().xbigger = xBigger;
        x.GetComponent<TentacleHeadInstantiateAnother>().CoordinateAndPlayerPosition = toward;
        x.GetComponent<TentacleHeadInstantiateAnother>().parent = gameObject;


    }
}


