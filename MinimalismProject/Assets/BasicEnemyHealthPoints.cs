using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthPoints : MonoBehaviour
{

    [SerializeField] private bool lol;

    public float knockback = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("Bullet"))
        {
            GameObject collider = collision.GetComponent<GameObject>();
            Vector3 toward = (gameObject.transform.position - collision.transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(toward.normalized * knockback, ForceMode2D.Impulse);
        }
    }
}
