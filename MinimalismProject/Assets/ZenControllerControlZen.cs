using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZenControllerControlZen : MonoBehaviour
{
    [SerializeField] private Slider sliderZen;
    [SerializeField] private Animator camAnim;
    static public float zen = 30;
    private float maxZen = 255;


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
        StartCoroutine(unwinlose());
    }

    public void lose()
    {
        camAnim.SetBool("Lose", true);
        StartCoroutine(unwinlose());
    }

    IEnumerator tickZen()
    {
        yield return new WaitForSeconds(0.1f);
        zen += 1.55f/10;
        StartCoroutine(tickZen());
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            zen -= 5;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            zen += 5;
        }
    }

    IEnumerator unwinlose()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        camAnim.SetBool("Win", false);
        camAnim.SetBool("Lose", false);

    }

}
