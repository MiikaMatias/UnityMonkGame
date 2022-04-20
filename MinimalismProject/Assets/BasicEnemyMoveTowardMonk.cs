using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoveTowardMonk : MonoBehaviour
{
    private GameObject player;

    [SerializeField] float speed = 10f;

    Vector3 toward; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(speedFluctuate());
    }
    void Update()
    {
        if (Time.timeScale != 0)
        {
            toward = (player.transform.position - transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(toward * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "VisionCone")
        {
            speed = speed * -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "VisionCone")
        {
            speed = Mathf.Abs(speed);
        }

    }

    IEnumerator speedFluctuate()
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
        
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(speedFluctuate());
    }

}
