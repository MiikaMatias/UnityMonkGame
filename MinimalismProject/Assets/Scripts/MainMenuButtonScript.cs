using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonScript : MonoBehaviour
{

    [SerializeField] private Animator MainMenuAnim;
    [SerializeField] private Animator SettingsAnim;
    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void settings()
    {
        MainMenuAnim.SetBool("MainMenuZoom", true);
        SettingsAnim.SetBool("SettingsComeBack", true);
    }

    public void backFromSettings()
    {
        MainMenuAnim.SetBool("MainMenuZoom", false);
        SettingsAnim.SetBool("SettingsComeBack", false);
    }
}
