using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawn : MonoBehaviour
{

    [SerializeField] private GameObject EnemyBasic;
    [SerializeField] private GameObject multiplier;
    [SerializeField] private GameObject powerup;

    private float difficultyMod = 1;

    private void Start()
    {
        StartCoroutine(SpawnScriptBasic());
        StartCoroutine(SpawnScriptMultiplier());
        StartCoroutine(SpawnScriptPowerUp());
        SetDifficultyMod();
    }

    private void SetDifficultyMod()
    {
        switch(SetDifficulty.difficulty)
        {
            case 0:
                difficultyMod = 1.25f;
                break;

            case 1:
                difficultyMod = 1;
                break;

            case 2:
                difficultyMod = 0.6f;
                break;
        }
        print(difficultyMod);
    }

    private void SpawnBasicEnemy()
    {
        Instantiate(EnemyBasic, transform.position, Quaternion.identity);
    }

    private void SpawnMultiplier()
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

    private void SpawnPowerup()
    {
        int y = 1000;
        int x = Random.Range(-500, 500);

        Instantiate(powerup, new Vector3(x, y, 0), Quaternion.identity);
    }

    private IEnumerator SpawnScriptBasic()
    {
        yield return new WaitForSeconds(Random.Range(0.5f*difficultyMod,2*difficultyMod));
        SpawnBasicEnemy();
        StartCoroutine(SpawnScriptBasic());
    }

    private IEnumerator SpawnScriptMultiplier()
    {
        yield return new WaitForSeconds(Random.Range(10*difficultyMod, 17f*difficultyMod));
        SpawnMultiplier();
        StartCoroutine(SpawnScriptMultiplier());
    }

    private IEnumerator SpawnScriptPowerUp()
    {
        yield return new WaitForSeconds(Random.Range(15*(2.5f-difficultyMod), 60f*(2.5f-difficultyMod)));
        SpawnPowerup();
        StartCoroutine(SpawnScriptPowerUp());
    }

}
