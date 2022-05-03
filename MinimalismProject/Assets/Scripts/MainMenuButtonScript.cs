using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonScript : MonoBehaviour
{

    [SerializeField] private Animator MainMenuAnim;
    [SerializeField] private Animator SettingsAnim;
    [SerializeField] private Animator CreditsAnim;
    [SerializeField] private Animator PauseAnim;
    [SerializeField] private Animator fader;

    private void Start()
    {




        if (SceneManager.GetActiveScene().name == "Game")
        {
            SettingsAnim.SetBool("IsPauseMenu", true);
            SettingsAnim = GameObject.FindGameObjectWithTag("SettingsAnim").GetComponent<Animator>();
        }
        else
        {
            MainMenuAnim = GameObject.FindGameObjectWithTag("MainMenuAnim").GetComponent<Animator>();
            CreditsAnim = GameObject.FindGameObjectWithTag("CreditsAnim").GetComponent<Animator>();
            SettingsAnim = GameObject.FindGameObjectWithTag("SettingsAnim").GetComponent<Animator>();

            MainMenuAnim.SetBool("MainMenuZoom", false);
            SettingsAnim.SetBool("SettingsComeBack", false);
            MainMenuAnim.SetBool("ShowCredits", false);
            CreditsAnim.SetBool("CreditsSlideIn", false);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(findPausemenuafterdelay());
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        ZenControllerControlZen.zen = 30;
        fader.SetBool("Fade", true);
    }

    public void settings()
    {
        MainMenuAnim.SetBool("MainMenuZoom", true);
        SettingsAnim.SetBool("SettingsComeBack", true);
    }

    public void backFromSettings()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            SettingsAnim.SetBool("SettingsOn", false);
            PauseAnim.SetBool("Settings", false);
        }
        else
        {
            MainMenuAnim.SetBool("MainMenuZoom", false);
            SettingsAnim.SetBool("SettingsComeBack", false);
        }
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

    private IEnumerator findPausemenuafterdelay()
    {
        yield return new WaitForSeconds(0.1f);
        PauseAnim = GameObject.FindGameObjectWithTag("PauseAnim").GetComponent<Animator>();
    }
}
