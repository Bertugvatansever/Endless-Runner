using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupPoints : MonoBehaviour
{
    public int scoretoGive;
    public Scoremanager thescoreManager;
    private Playercontrol playerrrrr;
    private AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        playerrrrr = FindObjectOfType<Playercontrol>();
        thescoreManager = FindObjectOfType<Scoremanager>();
        coinSound = GameObject.Find("Coin").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            coinSound.Play();
            if(playerrrrr.doublepointActive==true)
            {
                thescoreManager.Addpoint(scoretoGive * 2);
            }
            else
            {
                thescoreManager.Addpoint(scoretoGive);
            }
            thescoreManager.Addpoint(scoretoGive);
            gameObject.SetActive(false);
        }
    }
}
