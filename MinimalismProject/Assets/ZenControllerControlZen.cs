using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZenControllerControlZen : MonoBehaviour
{
    [SerializeField] private Slider sliderZen;
    [SerializeField] private Animator camAnim;
    public float zen = 0;
    private float maxZen = 100;


    private void Start()
    {
        sliderZen.maxValue = maxZen; 
        StartCoroutine(tickZen());
    }

    private void Update()
    {
        sliderZen.value = zen;
        if (zen >= maxZen)
        {
            win();
        }
        if(zen < 0)
        {
            lose();
        }
    }

    private void win()
    {
        camAnim.SetBool("Win", true);
    }

    public void lose()
    {
        camAnim.SetBool("Lose", true);
    }

    IEnumerator tickZen()
    {
        yield return new WaitForSeconds(1);
        zen += 0.5f;
        StartCoroutine(tickZen());
    }
}
