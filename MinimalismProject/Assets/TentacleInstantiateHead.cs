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

        Vector3 toward = default;

        int r = Random.Range(0, 2);
        if(r == 0)
        {
            float yOffset = player.transform.position.y + 2 * transform.position.y;
            toward = new Vector3 (player.transform.position.x, yOffset,player.transform.position.z) - gameObject.transform.position;
            xBigger = false;
        }
        else
        {
            float xOffset = player.transform.position.x + 2 * transform.position.x;
            toward = new Vector3(xOffset, player.transform.position.y, player.transform.position.z) - gameObject.transform.position;
            xBigger = true;
        }

        GameObject x = Instantiate(tentacleHead, gameObject.transform.position + toward.normalized*100, Quaternion.identity);
        x.transform.parent = gameObject.transform;
        x.GetComponent<TentacleHeadInstantiateAnother>().xbigger = xBigger;
        x.GetComponent<TentacleHeadInstantiateAnother>().CoordinateAndPlayerPosition = toward;
        x.GetComponent<TentacleHeadInstantiateAnother>().parent = gameObject;


    }
}


