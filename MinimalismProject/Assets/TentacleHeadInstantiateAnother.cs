using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHeadInstantiateAnother : MonoBehaviour
{
    [SerializeField] private GameObject tentacleHead;
    public GameObject parent;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shootPointForViewDir;
    [SerializeField] private GameObject circle;

    private GameObject next;

    private float mintime = 0.5f;
    private float maxtime = 1.5f;

    public float increment = 0.03f;
    public float Xmultiplier = default;
    public float Ymultiplier = default;

    public float step = 10;

    public bool xbigger = default;

    public Vector3 CoordinateAndPlayerPosition = default;

    private Vector3 toward;
    private Vector3 looktoward;
    private Vector3 player2tent;

    public float mod = 6000;

    private bool deathByWorm = false;

    void Start()
    {
        shootPointForViewDir = GameObject.FindGameObjectWithTag("ShootPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        circle = GameObject.FindGameObjectWithTag("Circle");
        StartCoroutine(headInst());
        StartCoroutine(checkIfnextExists());

    }

    private void Update()
    {
        looktoward = (circle.transform.position + shootPointForViewDir.transform.position).normalized;
        player2tent = (circle.transform.position + transform.position).normalized;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(circle.transform.position, shootPointForViewDir.transform.position);
        Debug.DrawLine(circle.transform.position, transform.position);

        looktoward = (circle.transform.position + shootPointForViewDir.transform.position).normalized;
        player2tent = (circle.transform.position + transform.position).normalized;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Circle"))
        {
            deathByWorm = true;
            mintime = 0;
            maxtime = 0.1f;
        }

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ZenControllerControlZen>().lose();
        }

    }

    IEnumerator headInst()
    {
        yield return new WaitForSeconds(0.5f);
        print(Vector3.Dot(player2tent, looktoward));
        if (Vector3.Dot(player2tent, looktoward) >= 0.8f || deathByWorm == true)
        {
            if (xbigger == false)
            {
                CoordinateAndPlayerPosition = new Vector3(player.transform.position.x + Random.Range(-mod, mod), Random.Range(CoordinateAndPlayerPosition.y * 0.6f, CoordinateAndPlayerPosition.y), CoordinateAndPlayerPosition.z);
            }
            else
            {
                CoordinateAndPlayerPosition = new Vector3(Random.Range(CoordinateAndPlayerPosition.x * 0.6f, CoordinateAndPlayerPosition.x), player.transform.position.y + Random.Range(-mod, mod), CoordinateAndPlayerPosition.z);
            }

            toward = (CoordinateAndPlayerPosition - transform.position).normalized;


            if (mod <= 0)
            {
                mod = 0;
            }
            else
            {
                mod -= mod / 40;
            }

            next = Instantiate(tentacleHead, transform.position + toward * 75, Quaternion.identity);
            gameObject.GetComponent<TentacleHeadsPullTogether>().child = next;
            next.transform.parent = parent.transform;
            next.GetComponent<TentacleHeadInstantiateAnother>().CoordinateAndPlayerPosition = CoordinateAndPlayerPosition;
            next.GetComponent<TentacleHeadInstantiateAnother>().xbigger = xbigger;
            next.GetComponent<TentacleHeadInstantiateAnother>().mod = mod;
            next.GetComponent<TentacleHeadInstantiateAnother>().parent = parent;
           
        }
    }

    IEnumerator checkIfnextExists()
    {
        yield return new WaitForSeconds(0.5f);
        if (next == null)
        {
            StartCoroutine(headInst());
        }
        StartCoroutine(checkIfnextExists());

    }
}
