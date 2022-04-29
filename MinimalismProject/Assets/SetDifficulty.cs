using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private TMP_Text easy, medium, hard;
    [SerializeField] private Slider slider;
    [SerializeField] private Color col, easycol, mediumcol, hardcol;



    static public int difficulty = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(slider.value < 0.35f)
        {
            easy.color = easycol;
            medium.color = col;
            hard.color = col;
            difficulty = 0;
        }

        if (slider.value >= 0.35f && slider.value <= 0.65f)
        {
            easy.color = col;
            medium.color = mediumcol;
            hard.color = col;
            difficulty = 1;
        }

        if (slider.value > 0.65f)
        {
            easy.color = col;
            medium.color = col;
            hard.color = hardcol;
            difficulty = 2;
        }
    }
}
