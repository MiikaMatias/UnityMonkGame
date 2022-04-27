using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ZenControllerControlZen.zen >= 255)
        {
            gameObject.GetComponent<Animator>().SetBool("Victory", true);
        }
    }
}
