using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGround : MonoBehaviour
{
    public int howManyMore = 93;
    public int spriteIndex = 0;
    public int spaceBetweenSprites = 128;

    [SerializeField] private GameObject tile;
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private GameObject childTile;
    void Start()
    {
        if (spriteIndex > 10)
        {
            spriteIndex = 0;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[spriteIndex];


        if (howManyMore > 0)
        {
            childTile = Instantiate(tile, new Vector3(transform.position.x + spaceBetweenSprites, transform.position.y, transform.position.z), Quaternion.identity);
            howManyMore -= 1;
            childTile.GetComponent<GenerateGround>().howManyMore = howManyMore;
            childTile.GetComponent<GenerateGround>().spriteIndex = spriteIndex + 1;
        }
    }

}
