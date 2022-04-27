using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAccelerateTowardPlayer : MonoBehaviour
{
    private GameObject player;
    Vector3 toward;

    public float forceStart = 50;
    public float forceIncremental = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        toward = player.transform.position - transform.position;
        StartCoroutine(periodicForce());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ZenControllerControlZen.zen -= 1;
            Destroy(gameObject);
        }

    }

    IEnumerator periodicForce()
    {
        yield return new WaitForSeconds(Random.Range(0, 0.4f));
        gameObject.GetComponent<Rigidbody2D>().AddForce(toward * forceIncremental, ForceMode2D.Impulse);
        StartCoroutine(periodicForce());
    }
}
