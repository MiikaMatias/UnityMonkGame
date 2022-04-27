using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWin : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if(ZenControllerControlZen.zen >= 255)
        {
            gameObject.GetComponent<Animator>().SetBool("Win", true);
            gameObject.GetComponent<Animator>().SetBool("Win", false);

        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Win", false);
        }
    }
}
