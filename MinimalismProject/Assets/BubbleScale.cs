using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScale : MonoBehaviour
{
    private bool positiveGrowth = true;

    public float scale = 3;
    public float growthRate = 0.001f;

    // Update is called once per frame

    private void Start()
    {
    
    }
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (positiveGrowth == true && gameObject.transform.localScale.x <= 13.5)
            {
                scale += growthRate;
            }
            gameObject.transform.localScale = new Vector3(scale, scale * 0.855f, transform.localScale.z);
        }

    }
}
