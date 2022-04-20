using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject player;

    [SerializeField] private float speed = 200;
    [SerializeField] private float cooldown = 2;

    private bool cooldownElapsed = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && cooldownElapsed == true)
        {
            print("Shot");
            StartCoroutine(shootWave());
        }
    }

    void shoot()
    {
        print("Bam");

        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector3 toward = new Vector2(transform.position.x, transform.position.y) - new Vector2(player.transform.position.x, player.transform.position.y);
        currentBullet.GetComponent<Rigidbody2D>().AddForce(toward.normalized * speed, ForceMode2D.Impulse);
        print(toward);
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
