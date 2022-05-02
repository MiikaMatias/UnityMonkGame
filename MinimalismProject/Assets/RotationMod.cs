using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMod : MonoBehaviour
{

    public float speed;
    public float rotationModifier;


    private GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;


        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;


        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);


        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }
}


