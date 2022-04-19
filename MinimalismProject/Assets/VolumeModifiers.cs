using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeModifiers : MonoBehaviour
{
    static public float masterSound = 0.75f;
    static public float music = 0.75f;
    static public float soundFX = 0.75f;

    [SerializeField] private TMP_Text MasterSoundPercentage;
    [SerializeField] private Slider MasterSound;

    [SerializeField] private TMP_Text MusicPercentage;
    [SerializeField] private Slider Music;

    [SerializeField] private TMP_Text SoundEffectsPercentage;
    [SerializeField] private Slider SFX;

    private void Start()
    {
        MasterSound.value = masterSound;
        Music.value = music;
        SFX.value = soundFX;
    }

    private void Update()
    {
        masterSound = MasterSound.value;
        MasterSoundPercentage.text = Mathf.RoundToInt(masterSound * 100f).ToString() + "%";

        music = Music.value;
        MusicPercentage.text = Mathf.RoundToInt(music * 100f).ToString() + "%";

        soundFX = SFX.value;
        SoundEffectsPercentage.text = Mathf.RoundToInt(soundFX * 100f).ToString() + "%";
    }
}
