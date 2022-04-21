using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bubble;

    [SerializeField] private float speed = 200;
    [SerializeField] private float cooldown = 2;

    private bool cooldownElapsed = true;

    private void Start()
    {
    }
    void Update()
    {
        if(cooldownElapsed == true)
        {
            StartCoroutine(shootWave());
        }
    }

    void shoot()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector3 toward = new Vector2(transform.position.x, transform.position.y) - new Vector2(bubble.transform.position.x, bubble.transform.position.y);
        currentBullet.GetComponent<Rigidbody2D>().AddForce(toward.normalized * speed, ForceMode2D.Impulse);
    }

    IEnumerator shootWave()
    {
        cooldownElapsed = false;
        shoot();
        yield return new WaitForSeconds(0.3f);
        shoot();
        yield return new WaitForSeconds(0.3f);
        shoot();
        yield return new WaitForSeconds(0.3f);

        yield return new WaitForSeconds(cooldown);
        cooldownElapsed = true;

    }

}
