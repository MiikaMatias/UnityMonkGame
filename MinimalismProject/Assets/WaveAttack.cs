using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    [SerializeField] private GameObject wave;

    public int cooldown = 10;
    public int setcooldownto = 15;

    private void Start()
    {
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            Instantiate(wave, transform.position, Quaternion.identity);
            cooldown = 15;
        }

        if(cooldown <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("HasWave", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("HasWave", false);
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(Random.Range(0.8f, 1.21f));
        cooldown -= 1;
        StartCoroutine(CountDown());
    }
}
