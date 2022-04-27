using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ZenControllerControlZen.zen <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Defeat", true);
        }
    }
}
