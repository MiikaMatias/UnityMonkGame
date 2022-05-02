using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCallSound : MonoBehaviour
{
    private GameObject audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("BulletAudioManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int random = Random.Range(0, 20);

            if (random <= 10)
            {
                audiomanager.GetComponent<BulletAudioManager>().PlaySound(random);
            }
        }
    }
}
