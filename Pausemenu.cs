using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    private float startcamSpeed;
    private float tempcamSpeed;
    public string mainmenuLevel;
    public Cameracontroller camspeed;
    public GameObject pauseMenu;
    private Gamemanager reset;
    public Playercontrol scoreCatcher;

   public void PauseGame()
    {
        tempcamSpeed = camspeed.cammovespeed;
        scoreCatcher = FindObjectOfType<Playercontrol>();
        Time.timeScale = 0f;
        camspeed.cammovespeed = 0;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        camspeed.cammovespeed = tempcamSpeed;
        pauseMenu.SetActive(false);
    }
    public void RestartGame()
    {
        startcamSpeed = 9f;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        camspeed.cammovespeed = startcamSpeed;
        camspeed.transform.position = camspeed.camstartPosition;
        reset = FindObjectOfType<Gamemanager>();
        reset.Restartgame();
        // Restart bugu çözüldü
        scoreCatcher.contact2 = false;
    }
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainmenuLevel);
    }
    
}
