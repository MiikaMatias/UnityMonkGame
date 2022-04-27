using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleRotate : MonoBehaviour
{
    private float rotationspeed = 3;

    private void Start()
    {
        StartCoroutine(changerot());
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime*rotationspeed);
    }

    IEnumerator changerot()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        float futurespeed = default;
        if (rotationspeed < 0)
        {
            futurespeed = Random.Range(0, 5f);
        }
        else
        {
            futurespeed = Random.Range(-5, 0f);

        }
        int i = 100;
        StartCoroutine(changespeed(i, futurespeed));
    }

    IEnumerator changespeed(int i, float futurespeed)
    {
        i -= 1;
        yield return new WaitForEndOfFrame();
        if (i >= 0)
        {
            rotationspeed += futurespeed / 100;
            StartCoroutine(changespeed(i, futurespeed));
        }
        else
        {
            StartCoroutine(changerot());
        }
        
    }
}
