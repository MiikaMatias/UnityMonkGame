using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyHealthPoints : MonoBehaviour
{

    [SerializeField] private bool lol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            print("caca");
        }
    }
}
