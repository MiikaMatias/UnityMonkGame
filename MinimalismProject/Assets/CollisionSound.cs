using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private bool inbubble;
    [SerializeField] GameObject bassPlayer;

    private void Awake()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            bassPlayer.GetComponent<PlayBassEnemy>().enemyInBubble = true;
        }
        else
        {
            bassPlayer.GetComponent<PlayBassEnemy>().enemyInBubble = false;
        }

    }


}
