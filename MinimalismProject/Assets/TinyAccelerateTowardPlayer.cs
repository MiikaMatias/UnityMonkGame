using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAccelerateTowardPlayer : MonoBehaviour
{
    private GameObject player;
    Vector3 toward;

    public float forceStart = 50;
    public float forceIncremental = 5;

    private bool ded = false;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        player = GameObject.FindGameObjectWithTag("Player");
        toward = player.transform.position - transform.position;
        StartCoroutine(periodicForce());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ded == false)
        {
            ZenControllerControlZen.zen -= 5;
            Destroy(gameObject);
        }

        if(collision.CompareTag("Wave"))
        {
            ded = true;
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }

        if (collision.CompareTag("Circle"))
        {
            gameObject.GetComponent<Animator>().SetBool("InBubble", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Circle"))
        {
            gameObject.GetComponent<Animator>().SetBool("InBubble", false);
        }
    }

    IEnumerator periodicForce()
    {
        yield return new WaitForSeconds(Random.Range(0, 0.4f));
        gameObject.GetComponent<Rigidbody2D>().AddForce(toward * forceIncremental, ForceMode2D.Impulse);
        StartCoroutine(periodicForce());
    }

    public void die()
    {
        Destroy(gameObject);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
