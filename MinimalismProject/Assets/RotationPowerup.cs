using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPowerup : MonoBehaviour
{
    private Vector3 offset = default;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         offset = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(
                       Vector3.forward, // Keep z+ pointing straight into the screen.
                       offset           // Point y+ toward the target.
                     );
    }




}
