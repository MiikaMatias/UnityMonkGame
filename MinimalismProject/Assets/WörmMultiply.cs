using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmMultiply : MonoBehaviour
{
    [SerializeField] private GameObject wörmBody;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject child;

    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject shootpoint;

    public GameObject firstWörm;

    Vector3 toward;

    public float instantiateDistance = 50;

    public bool destroy = false;

    private void Start()
    {
        findObjects();
        getToward();
        StartCoroutine(instantiateHead());
    }

    private void findObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        circle = GameObject.FindGameObjectWithTag("Circle");
        shootpoint = GameObject.FindGameObjectWithTag("ShootPoint");
    }

    private void getToward()
    {
        toward = (player.transform.position) - transform.position;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Circle"))
        {
            destroy = true;
        }

        if (collision.CompareTag("Player"))
        {
            ZenControllerControlZen.zen -= 5;
        }
    }
    private IEnumerator instantiateHead()
    {
        if (child == null)
        {
            yield return new WaitForSeconds(Random.Range(0.6f,1.4f));
            testLookDir();
            StartCoroutine(instantiateHead());
        }
    }

    private void setAsParent()
    {
        child.transform.parent = firstWörm.transform;
    }

    private void testLookDir()
    {
        Vector3 circle2Shootpoint = shootpoint.transform.position - circle.transform.position;
        Vector3 circle2wörm = transform.position - circle.transform.position;
        float dot = Vector3.Dot(circle2Shootpoint.normalized, circle2wörm.normalized);
        if (dot > 0.9f || destroy == true)
        {
            child = Instantiate(wörmBody, transform.position + toward.normalized * instantiateDistance, Quaternion.identity);
            setAsParent();
            wörmDistManager();
        }
    }

    private void wörmDistManager()
    {
        gameObject.GetComponent<WörmDistanceBetweenManager>().child = child;
    }

}
