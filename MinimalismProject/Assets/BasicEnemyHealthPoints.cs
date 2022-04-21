using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthPoints : MonoBehaviour
{
    public float knockback = 20;
    public bool destructable = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ZenControllerControlZen>().zen -= 5;
            Destroy(gameObject);
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
            print(destructable);
        }
    }

    private IEnumerator slowdown(Vector3 toward, float i)
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

}
