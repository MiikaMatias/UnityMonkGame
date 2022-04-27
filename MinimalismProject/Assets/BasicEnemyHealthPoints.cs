using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthPoints : MonoBehaviour
{
    public float knockback = 20;
    public bool destructable = false;
    
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(loseZen(15));
        }

        if (collision.CompareTag("Bullet"))
        {
            if (destructable == true)
            {
                Vector3 toward = (gameObject.transform.position - collision.transform.position);
                gameObject.GetComponent<Rigidbody2D>().AddForce(toward.normalized * knockback, ForceMode2D.Impulse);
                StartCoroutine(slowdown(toward, 0));
            }
        }

        if (collision.CompareTag("Destructable"))
        {
            destructable = true;
        }

        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    public void stopCoroutine()
    {
        StopAllCoroutines();
    }
    public IEnumerator slowdown(Vector3 toward, float i)
    {
        i += 0.1f;
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(-toward.normalized * knockback/10, ForceMode2D.Impulse);
        if (i < 1)
        {
            StartCoroutine(slowdown(toward, i));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<BasicEnemyMoveTowardMonk>().isHit = false;
        }
    }



    IEnumerator loseZen(float dmg)
    {
        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        yield return new WaitForSeconds(0.1f);
        ZenControllerControlZen.zen -= dmg / 10;

        Destroy(gameObject);


    }

}
