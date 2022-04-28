using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpApproachPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private GameObject shootpoint;

    private float speed = 100;

    Vector3 offset;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(VertForce());
        shootpoint = GameObject.FindGameObjectWithTag("ShootPoint");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        offset = player.transform.position - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shootpoint.GetComponent<BulletPointShoot>().powerUp();
        }
    }

    private IEnumerator VertForce()
    {
        yield return new WaitForSeconds(Random.Range(4, 6));
        int i = Random.Range(0, 2);

        if (i == 1)
        {
            rb.AddForce(Vector3.right * 1.5f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector3.left * 1.5f, ForceMode2D.Impulse);
        }

        StartCoroutine(VertForce());

    }
}
