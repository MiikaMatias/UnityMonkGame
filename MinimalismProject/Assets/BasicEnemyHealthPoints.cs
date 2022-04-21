using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthPoints : MonoBehaviour
{
    public float knockback = 20;
    public bool destructable = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<ZenControllerControlZen>().zen -= 5;
            Destroy(gameObject);
        }

        if(collision.CompareTag("Bullet"))
        {
            if(destructable == true)
            { 
            GameObject collider = collision.GetComponent<GameObject>();
            Vector3 toward = (gameObject.transform.position - collision.transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(toward.normalized * knockback, ForceMode2D.Impulse);
            }
        }

        if(collision.CompareTag("Destructable"))
        {
            destructable = true;
            print(destructable);
        }
    }
}
