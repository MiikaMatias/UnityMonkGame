using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    private GameObject pauseManager;
    private Animator SettingsAnim;
    private Animator basicButtons;

    private void Start()
    {
        if (SettingsAnim != null)
        {
            SettingsAnim = GameObject.FindGameObjectWithTag("SettingsAnim").GetComponent<Animator>();
        }
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        basicButtons = GameObject.FindGameObjectWithTag("PauseAnim").GetComponent<Animator>();

        SettingsAnim.SetBool("IsPauseMenu", true);
    }

    public void unpause()
    {
        pauseManager.GetComponent<PauseMenuManager>().unpause();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void settings()
    {
        basicButtons.SetBool("Settings", true);
        SettingsAnim.SetBool("SettingsOn", true);
    }

    public void replay()
    {
        ZenControllerControlZen.zen = 30;
        SceneManager.LoadScene("Game");
    }
}
