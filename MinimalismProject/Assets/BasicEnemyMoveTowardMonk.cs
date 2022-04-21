using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoveTowardMonk : MonoBehaviour
{
    private GameObject player;

    [SerializeField] float speed = 10f;
    [SerializeField] float cooldownAmount = 5;
    public bool isHit = false;

    Vector3 toward; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(speedFluctuate());
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
            StopCoroutine(cooldown());
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
            isHit = true;
            StartCoroutine(cooldown());
            print(isHit);
        }
    } 

    IEnumerator speedFluctuate()
    {
        if (isHit == false)
        {
            speed = speed * 0.5f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed = speed * 0.5f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed = speed * 0.5f;

            yield return new WaitForSeconds(Random.Range(1, 3));
            speed = speed * 2f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed = speed * 2f;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            speed = speed * 2f;
        }
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(speedFluctuate());
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(cooldownAmount);
        isHit = false;
    }

}
