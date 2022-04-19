using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawn : MonoBehaviour
{

    [SerializeField] private GameObject EnemyBasic;
    void Start()
    {
        StartCoroutine(SpawnScript());
    }

    // Update is called once per frame
    void SpawnBasicEnemy()
    {
        Instantiate(EnemyBasic, transform.position, Quaternion.identity);
    }

    IEnumerator SpawnScript()
    {
        yield return new WaitForSeconds(Random.Range(2,8));
        SpawnBasicEnemy();
        StartCoroutine(SpawnScript());
    }
}
