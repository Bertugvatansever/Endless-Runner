using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject shield2;
    public GameObject shield;
    private Lifebar lifeReset;
    public Transform platformGenerator;
    public Playercontrol player;
    private Platformdestroyer[] platformList;
    public Scoremanager thescoreManager;
    public Characterselector characterselect;
    private Vector3 platformstartPoint;
    private Vector3 playerstartPoint;
    private string ninjabeginHealth;
    private string playerbeginHealth;

    // Start is called before the first frame update
    void Start()
    {
        lifeReset = FindObjectOfType<Lifebar>();
        player = FindObjectOfType<Playercontrol>();
        platformstartPoint = platformGenerator.position;
        playerstartPoint = player.transform.position;
        ninjabeginHealth = PlayerPrefs.GetString("ninjaSelect");
        playerbeginHealth = PlayerPrefs.GetString("playerSelect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restartgame()
    {
        StartCoroutine("RestartgameCo");
    }
    // oyun tekrar baþlar
    public IEnumerator RestartgameCo()
    {
        shield2.gameObject.SetActive(false);
        shield.gameObject.SetActive(false);
        thescoreManager.scoreIncreasing = false;
        player.safeMode = false;
        player.doublepointActive = false;
        player.gameObject.SetActive(false);
        platformList = FindObjectsOfType<Platformdestroyer>();
        for(int i = 0;i<platformList.Length;i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerstartPoint;
        platformGenerator.position = platformstartPoint;
        player.moveSpeed = player.beginnermoveSpeed;
        player.speedmilestoneCount = player.beginnerspeedmilestoneCount;
        player.speedýncreaseMilestone = player.beginnerspeedýncreaseMilestone;
        player.gameObject.SetActive(true);
        if(ninjabeginHealth == "true")
        {
            lifeReset.health = 100f;
        }
        else
        {
            lifeReset.health = 200f;
        }
        thescoreManager.scoreCount = 0;
        player.catcher = true;
        yield return new WaitForSeconds(0.5f);
    }
}
