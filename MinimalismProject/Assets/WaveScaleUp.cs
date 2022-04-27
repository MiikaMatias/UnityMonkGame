using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScaleUp : MonoBehaviour
{
    private GameObject circle;

    private Color color;

    public GameObject[] bullet;

    private void Start()
    {
        circle = GameObject.FindGameObjectWithTag("Circle");
    }

    void Update()
    {
        WaveAttack();
        color = new Vector4(255, 255, 255, 255);

    }

    void WaveAttack()
    {
        if (transform.localScale.x <= circle.transform.localScale.x * 0.667)
        {
            print(Mathf.Abs((color.a - color.a * (circle.transform.localScale.x * 0.667f / transform.localScale.x))/255));
            color = new Vector4(255, 255, 255, Mathf.Abs((color.a - color.a * (circle.transform.localScale.x * 0.667f / transform.localScale.x)) / 255));
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, transform.localScale.z);
            bullet[0].GetComponent<SpriteRenderer>().color = color;
            bullet[1].GetComponent<SpriteRenderer>().color = color;
            bullet[2].GetComponent<SpriteRenderer>().color = color;
            bullet[3].GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
