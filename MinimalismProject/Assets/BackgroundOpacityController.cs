using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundOpacityController : MonoBehaviour
{
    [SerializeField] private Image basic;
    [SerializeField] private Image win;
    [SerializeField] private Image lose;

    private float zen;
    private float basezenvalue;

    private void Update()
    {
        zen = ZenControllerControlZen.zen;

        basezenvalue = (-0.00392f * (zen*zen) + 255)/255;

        if(basezenvalue < 0)
        {
            basezenvalue = 0;
        }

        var tempcolor = basic.color;
        tempcolor.a = basezenvalue;
        basic.color = tempcolor;

        if (zen >= 155)
        {
            tempcolor = win.color;
            tempcolor.a = (zen - 155)*2.55f;
            win.color = tempcolor;
        }
        else
        {
            tempcolor = win.color;
            tempcolor.a = 0;
            win.color = tempcolor;
        }

        if (zen < 100)
        {
            tempcolor = lose.color;
            tempcolor.a = (255-zen*2.55f)/255;
            lose.color = tempcolor;
        }
        else
        {
            tempcolor = lose.color;
            tempcolor.a = (100 - zen)/255;
            lose.color = tempcolor;
        }

    }
}
