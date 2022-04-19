using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private GameObject pausemenu;
    [SerializeField] private GameObject pausemenuinst;

    public bool ispaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & ispaused == true)
        {
            unpause();
        }
        else
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }

    }

    public void pause()
    {
        pausemenu = Instantiate(pausemenuinst, gameObject.transform.position, Quaternion.identity);
        ispaused = true;
        Time.timeScale = 0;
    }


    public void unpause()
    {
        Destroy(pausemenu);
        ispaused = false;
        Time.timeScale = 1;
    }
}
