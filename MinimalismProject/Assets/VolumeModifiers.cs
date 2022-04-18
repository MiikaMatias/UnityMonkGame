using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeModifiers : MonoBehaviour
{
    static public float masterSound = 1;
    static public float music = 1;
    static public float soundFX = 1;

    [SerializeField] private TMP_Text MasterSoundPercentage;
    [SerializeField] private Slider MasterSound;

    [SerializeField] private TMP_Text MusicPercentage;
    [SerializeField] private Slider Music;

    [SerializeField] private TMP_Text SoundEffectsPercentage;
    [SerializeField] private Slider SFX;


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
