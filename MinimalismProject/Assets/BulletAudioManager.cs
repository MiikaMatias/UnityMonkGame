using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class BulletAudioManager : MonoBehaviour
{
    public AudioClip[] audio;
    [SerializeField] private AudioSource source;
    private bool soundCoolDown = false;
    public bool ChantOver = false;

    private void Update()
    {
        source.volume = 0.1f * VolumeModifiers.soundFX;
    }

    public void PlaySound(int random)
    {
        if (soundCoolDown == false && ChantOver == true)
        {
            StartCoroutine(soundCD());
            source.clip = audio[random];
            source.Play();
        }
    }

    IEnumerator soundCD()
    {
        soundCoolDown = true;

        yield return new WaitForSeconds(0.75f);

        soundCoolDown = false;

    }
}
