using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PauseMenu : MonoBehaviour
{
    public static bool game_pause = false;
    public GameObject pause_UI;

    public void f_Pause()    //function called when the "Resume" button is pressed
    {
        if (game_pause == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        pause_UI.SetActive(false);   //deactivates the UI
        Time.timeScale = 1f;    //sets the game speed to 1 (normal time)
        game_pause = false;
    }

    private void Pause()
    {
        pause_UI.SetActive(true);   //activates the UI
        Time.timeScale = 0f;    //sets the game speed to 0 (freezes time)
        game_pause = true;
    }
}
