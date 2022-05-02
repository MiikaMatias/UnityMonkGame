using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    private void Awake()
    {
        audio.volume = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        audio.volume = 0.5f * VolumeModifiers.soundFX;

        if (collision.CompareTag("Enemy"))
        {
            audio.volume = 1;
        }
        else
        {
            audio.volume = 0;
        }
    }

}
