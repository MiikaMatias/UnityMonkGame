using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHeadsPullTogether : MonoBehaviour
{
    public GameObject child;

    Vector3 toward;

    private void FixedUpdate()
    {
        if (child != null)
        {
            child.transform.position = Vector3.MoveTowards(child.transform.position, transform.position, TentacleSpeedControl.speed);
        }
    }

}
