using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathmenu : MonoBehaviour
{
    private float startcamSpeed2;
    public string mainmenuLevel;
    public Gamemanager restartgame;
    public GameObject deathMenu;
    public Cameracontroller thecameramoveSpeed;

   public void Restartgame()
    {
        Time.timeScale = 1f;
        startcamSpeed2 = 9f;
        thecameramoveSpeed.transform.position = thecameramoveSpeed.camstartPosition;
        restartgame = FindObjectOfType<Gamemanager>();
        restartgame.Restartgame();
        thecameramoveSpeed.cammovespeed = startcamSpeed2;
        deathMenu.SetActive(false);
    }

    public void Quitmenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainmenuLevel);
    }
    
    

    

   
}
