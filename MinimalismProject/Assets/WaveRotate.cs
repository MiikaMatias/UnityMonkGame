using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 50);
    }
}
