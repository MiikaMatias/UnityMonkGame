using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class TransitionFXMenu : MonoBehaviour
{
    public void sfx()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
