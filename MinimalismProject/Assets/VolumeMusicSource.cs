using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMusicSource : MonoBehaviour
{
    [SerializeField] private AudioSource musicPlayer;
    void Update()
    {
        musicPlayer.volume = VolumeModifiers.masterSound * VolumeModifiers.music;
    }
}
