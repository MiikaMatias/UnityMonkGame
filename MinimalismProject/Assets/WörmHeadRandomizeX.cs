using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmHeadRandomizeX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(-1600, 1600), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
