using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    [SerializeField] private float growthRate = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gameObject.transform.localScale = new Vector3(transform.localScale.x + growthRate * 2, transform.localScale.y + growthRate / 3, transform.localScale.z);
        }
    }
}
