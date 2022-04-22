using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAnimate : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<BasicEnemyMoveTowardMonk>().isHit == false)
        {
            anim.SetBool("IsHit", false);
        }
        else
        {
            anim.SetBool("IsHit", true);
        }
    }
}
