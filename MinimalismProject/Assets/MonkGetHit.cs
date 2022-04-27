using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkGetHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(collision.transform.position.x >= transform.position.x)
            {
                gameObject.GetComponent<Animator>().SetBool("Hitright", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Hitleft", true);
            }
            StartCoroutine(falsify());

        }
    }

    IEnumerator falsify()
    {
        yield return new WaitForSeconds(0.75f);
        gameObject.GetComponent<Animator>().SetBool("Hitright", false);
        gameObject.GetComponent<Animator>().SetBool("Hitleft", false);

    }
}
