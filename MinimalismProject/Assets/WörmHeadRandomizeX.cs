using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmHeadRandomizeX : MonoBehaviour
{

    [SerializeField] private bool bikkhu = false;
    void Awake()
    {
        if(bikkhu == true)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                transform.position = new Vector3(-1620, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(1620, transform.position.y, transform.position.z);
            }

            transform.position = new Vector3(transform.position.x, Random.Range(-1400, 0) + transform.position.y, transform.position.z);


        }
        else
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-1600, 1600), transform.position.y, transform.position.z);
        }


        if (SetDifficulty.difficulty != 2 && bikkhu == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
