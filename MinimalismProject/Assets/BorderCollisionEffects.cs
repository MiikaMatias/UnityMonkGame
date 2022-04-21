using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollisionEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemy") && collision.GetComponent<BasicEnemyHealthPoints>().destructable == true)
        {
            Destroy(collision.gameObject);
        }
    }
}
