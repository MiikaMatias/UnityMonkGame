using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoveTowardMonk : MonoBehaviour
{
    private GameObject player;

    [SerializeField] float speed = 10f;
    private float startspeed;
    [SerializeField] float cooldownAmount = 5;
    public bool isHit = false;

    Vector3 toward; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(speedFluctuate());
        startspeed = speed;
    }
    void Update()
    {
        if (Time.timeScale != 0 && isHit == false)
        {
            toward = (player.transform.position - transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(toward * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
            gameObject.GetComponent<BasicEnemyHealthPoints>().stopCoroutine();
            isHit = false;
            isHit = true;
        }
    } 

    IEnumerator speedFluctuate()
    {
        if (isHit == false)
        {
            speed -= startspeed * 0.4f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed -= startspeed * 0.4f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed -= startspeed * 0.4f;

            yield return new WaitForSeconds(Random.Range(1, 3));
            speed += startspeed * 0.4f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed += startspeed * 0.4f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed += startspeed * 0.4f;
        }
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(speedFluctuate());
    }

}
