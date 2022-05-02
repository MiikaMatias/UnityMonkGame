using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audiomanager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audio;
    private AudioSource audioObject;

    private float basevolume = 0;

    void Awake()
    {
        audioObject = gameObject.GetComponent<AudioSource>();
        if (gameObject.CompareTag("Melody"))
        {
            StartCoroutine(StartMelody());
        }
        if(gameObject.CompareTag("Spice"))
        {
            StartCoroutine(PlaySpice());
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioObject.volume = basevolume * VolumeModifiers.masterSound * VolumeModifiers.music;
    }

    private IEnumerator StartMelody()
    {
        yield return new WaitForSeconds(28f);
        GameObject.FindGameObjectWithTag("BulletAudioManager").GetComponent<BulletAudioManager>().ChantOver = true;
        StartCoroutine(FadeIn(0.1f));
        audioObject.clip = audio[1];
        audioObject.Play();
    }

    private IEnumerator PlaySpice()
    {
        yield return new WaitForSeconds(27.32f);
        StartCoroutine(FadeIn(0.5f));
        audioObject.clip = audio[2];
        audioObject.Play();
    }

    private IEnumerator FadeIn(float i)
    {
        if(i >= 1) { basevolume = 1;  yield break; }
        yield return new WaitForSeconds(0.3f);
        i += 0.030f;
        basevolume = i;
        print(audioObject.volume);
        StartCoroutine(FadeIn(i));
    }
}
