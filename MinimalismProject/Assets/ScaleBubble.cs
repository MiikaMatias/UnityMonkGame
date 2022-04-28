using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBubble : MonoBehaviour
{
    public float scale = 3;

    private void Start()
    {
        scaleBubble();
    }


    private void Update()
    {
        transform.localScale = new Vector3(scale, scale * 0.855f, transform.localScale.z);

        if (Time.timeScale != 0)
        {
            if (gameObject.transform.localScale.x < 12)
            {
                scale = ZenControllerControlZen.zen /ZenControllerControlZen.maxZen*12;
                if(scale <= 2.2f)
                {
                    scale = 2.2f;
                }
            }
            else
            {
                transform.localScale = new Vector3(12, 12 * 0.855f, transform.localScale.z);
            }
        }

    }
    public void scaleBubble()
    {
        transform.localScale = new Vector3(scale, scale * 0.855f, transform.localScale.z);

    }
}
