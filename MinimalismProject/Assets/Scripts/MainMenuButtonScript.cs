using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonScript : MonoBehaviour
{

    [SerializeField] private Animator MainMenuAnim;
    [SerializeField] private Animator SettingsAnim;
    [SerializeField] private Animator CreditsAnim;
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

    public void credits()
    {
        MainMenuAnim.SetBool("ShowCredits", true);
        CreditsAnim.SetBool("CreditsSlideIn", true);
    }

    public void backFromCredits()
    {
        MainMenuAnim.SetBool("ShowCredits", false);
        CreditsAnim.SetBool("CreditsSlideIn", false);
    }
}
