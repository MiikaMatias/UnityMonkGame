using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBubble : MonoBehaviour
{
    public float scale = 3;
    public float growthRate = 0.001f;

    private void Start()
    {
        scaleBubble();
    }


    private void Update()
    {
        transform.localScale = new Vector3(scale, scale * 0.855f, transform.localScale.z);

        if (Time.timeScale != 0)
        {
            if (gameObject.transform.localScale.x <= 9)
            {
                print(scale);
                scale += growthRate;
            }
        }

    }
    public void scaleBubble()
    {
        transform.localScale = new Vector3(scale, scale * 0.855f, transform.localScale.z);

    }
}
