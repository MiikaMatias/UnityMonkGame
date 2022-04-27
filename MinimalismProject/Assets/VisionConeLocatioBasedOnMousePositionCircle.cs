using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeLocatioBasedOnMousePositionCircle : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject bubble;

    
    Vector3 mousepos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        mousepos = Input.mousePosition;
        transform.position = mousepos;
    }
}
