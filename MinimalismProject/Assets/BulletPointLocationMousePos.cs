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
            //mousepos = cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            mousepos = new Vector3 (Input.mousePosition.x-1920/2, Input.mousePosition.y - 1080/2,0);
            float radius = bubble.transform.localScale.x;
            transform.position = bubble.transform.position + (bubble.transform.position + mousepos).normalized * radius * 50;
        }
    }
}
