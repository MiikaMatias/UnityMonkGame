using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currentBullet.transform.rotation = Quaternion.LookRotation(player.transform.position, Vector3.forward);

        }
    }
}
