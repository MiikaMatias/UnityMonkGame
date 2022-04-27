using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawn : MonoBehaviour
{

    [SerializeField] private GameObject EnemyBasic;
    [SerializeField] private GameObject multiplier;
    void Start()
    {
        StartCoroutine(SpawnScriptBasic());
        StartCoroutine(SpawnScriptMultiplier());
    }

    // Update is called once per frame
    void SpawnBasicEnemy()
    {
        Instantiate(EnemyBasic, transform.position, Quaternion.identity);
    }

    void SpawnMultiplier()
    {
        int x = default;
        int whichOne = Random.Range(0, 2);
        if(whichOne == 1)
        {
            x = 1700;
        }
        else
        {
            x = -1700;
        }

        int y = Random.Range(0, 651);

        Instantiate(multiplier, new Vector3 (x,y,0), Quaternion.identity);

    }

    IEnumerator SpawnScriptBasic()
    {
        yield return new WaitForSeconds(Random.Range(2,8));
        SpawnBasicEnemy();
        StartCoroutine(SpawnScriptBasic());
    }

    IEnumerator SpawnScriptMultiplier()
    {
        yield return new WaitForSeconds(Random.Range(10, 40f));
        SpawnMultiplier();
        StartCoroutine(SpawnScriptMultiplier());
    }
}
