using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointLocationMousePos : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bubble;


    Vector3 mousepos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            mousepos = cam.ScreenToWorldPoint(new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
            float radius = bubble.transform.localScale.x;
            Vector2 add = (mousepos - bubble.transform.position);
            transform.position = new Vector2(bubble.transform.position.x, bubble.transform.position.y) + add.normalized * radius * 50;
        }
    }
}
