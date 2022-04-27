using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixZ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f));
    }
}
