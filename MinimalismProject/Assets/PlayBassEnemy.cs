using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayBassEnemy : MonoBehaviour
{
    public bool enemyInBubble = false;
    [SerializeField] private AudioSource audio;
    private float SoundIncrement = 0.1f, prevolume = 0.5f;

    private void Awake()
    {
        audio.volume = 0; 
    }
    private void Update()
    {
        if(enemyInBubble == true)
        {
            increaseVolume();
        }
        else
        {
            prevolume -= SoundIncrement;
        }

        SetVolume();
    }

    private void increaseVolume()
    {
        if(audio.volume < 1)
        {
            prevolume += SoundIncrement;
        }
    }

    private void SetVolume()
    {
        audio.volume = prevolume*VolumeModifiers.soundFX;
    }
}
