using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorRotate : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.Rotate(0, 0, 1, Space.Self);
        }
    }
}
