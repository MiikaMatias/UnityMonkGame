using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHeadInstantiateAnother : MonoBehaviour
{
    [SerializeField] private GameObject tentacleHead;
    public GameObject parent;
    [SerializeField] private GameObject player;

    public float Xupmod = 2.0f;
    public float Xdownmod = 1.6f;

    public float Yupmod = 2.0f;
    public float Ydownmod = 1.6f;




    public float increment = 0.03f;
    public float Xmultiplier = default;
    public float Ymultiplier = default;

    public float step = 10;

    public bool xbigger = default;

    public Vector3 CoordinateAndPlayerPosition = default;

    private Vector3 toward;
    public float mod = 6000;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(headInst());

    }

    private void Update()
    {
    }

    IEnumerator headInst()
    {
        yield return new WaitForSeconds(Random.Range(0.4f, 1.2f));
        if(xbigger == false)
        {
            CoordinateAndPlayerPosition = new Vector3(player.transform.position.x + Random.Range(-mod,mod), Random.Range(CoordinateAndPlayerPosition.y*0.6f,CoordinateAndPlayerPosition.y), CoordinateAndPlayerPosition.z);
        }
        else
        {
            CoordinateAndPlayerPosition = new Vector3(Random.Range(CoordinateAndPlayerPosition.x * 0.6f, CoordinateAndPlayerPosition.x), player.transform.position.y + Random.Range(-mod, mod), CoordinateAndPlayerPosition.z);

        }

        toward = (CoordinateAndPlayerPosition - transform.position).normalized;


        if(mod <= 0)
        {
            mod = 0;
        }
        else
        {
            mod -= mod / 40;
        }

        print(CoordinateAndPlayerPosition);


        GameObject next = Instantiate(tentacleHead, transform.position + toward * 75, Quaternion.identity);
        next.GetComponent<TentacleHeadInstantiateAnother>().CoordinateAndPlayerPosition = CoordinateAndPlayerPosition;
        next.GetComponent<TentacleHeadInstantiateAnother>().xbigger = xbigger;
        next.GetComponent<TentacleHeadInstantiateAnother>().mod = mod;



    }
}
