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
    static public float maxZen = 255;

    private float difficultyMod = 1;


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
        zen += 1.75f/10*difficultyMod;
        StartCoroutine(tickZen());
    }

    IEnumerator unwinlose()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        camAnim.SetBool("Win", false);
        camAnim.SetBool("Lose", false);

    }

    private void SetDifficultyMod()
    {
        switch (SetDifficulty.difficulty)
        {
            case 0:
                difficultyMod = 1.2f;
                break;

            case 1:
                difficultyMod = 1;
                break;

            case 2:
                difficultyMod = 0.8f;
                break;
        }
        print(difficultyMod);
    }

}
