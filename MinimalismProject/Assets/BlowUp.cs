using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{
    [SerializeField] private GameObject tiny;

    public float force = 200;

    private bool destructable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Destructable"))
        {
            StartCoroutine(MakeDestructable());
        }

        if(collision.CompareTag("Bullet") && destructable == true )
        {
            StartCoroutine(InstantiateTiny());
        }
    }

    IEnumerator InstantiateTiny()
    {
        gameObject.GetComponent<MultiplierMovement>().persec = 0;
        for(int i = Random.Range(2, 6); i > 0; i--)
        {
            yield return new WaitForSeconds(Random.Range(0, 1f));
            Vector3 randomVector = new Vector3(Random.Range(-40, 40), Random.Range(-40, 40), 0);
            GameObject x = Instantiate(tiny, gameObject.transform.position + randomVector, Quaternion.identity);
            x.GetComponent<Rigidbody2D>().AddForce(randomVector.normalized * force, ForceMode2D.Impulse);
        }
        
        
        Destroy(gameObject);

    }

    private IEnumerator MakeDestructable()
    {
        yield return new WaitForSeconds(3);
        destructable = true;
    }
}
