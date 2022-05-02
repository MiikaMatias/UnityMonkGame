using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MonkGetHit : MonoBehaviour
{
    [SerializeField] private Animator cam;
    [SerializeField] private AudioClip[] hurt;
    [SerializeField] private AudioSource source;

    private bool CooldownSound = false;

    private void Update()
    {
        source.volume = 1 * VolumeModifiers.soundFX;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            PlayHurt();
            if(collision.transform.position.x >= transform.position.x)
            {
                gameObject.GetComponent<Animator>().SetBool("Hitright", true);
                cam.SetBool("Hurt", true);
            }

            if (collision.transform.position.x < transform.position.x)
            {
                gameObject.GetComponent<Animator>().SetBool("Hitleft", true);
                cam.SetBool("Hurt", true);
            }
            StartCoroutine(falsify());

        }
    }

    private IEnumerator falsify()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Animator>().SetBool("Hitright", false);
        gameObject.GetComponent<Animator>().SetBool("Hitleft", false);
        cam.SetBool("Hurt", false);
    }

    private IEnumerator SoundCD()
    {
        CooldownSound = true;
        yield return new WaitForSeconds(0.75f);
        CooldownSound = false;
    }

    private void PlayHurt()
    {
        if (CooldownSound == false)
        {
            int random = Random.Range(0, 4);
            source.clip = hurt[random];
            source.Play();
            StartCoroutine(SoundCD());
        }
    }
}
