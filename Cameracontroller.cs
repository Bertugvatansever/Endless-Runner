using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Scoremanager getScore;
    public Playercontrol player;
    //public Vector3 lastplayerPosition;
    //private float distancetoMove;
    public float cammovespeed;
    public Vector3 camstartPosition;
    // Start is called before the first frame update
    void Start()
    {
        getScore = FindObjectOfType<Scoremanager>();
        player = FindObjectOfType<Playercontrol>();
        //lastplayerPosition = player.transform.position;
        cammovespeed = 9f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.thecountDown.countDown==0)
        {
            transform.position = new Vector3(transform.position.x + cammovespeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if(player.thedeathmenu.activeInHierarchy)
        {
            cammovespeed = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x >player.speedmilestoneCount)
        {
            cammovespeed = cammovespeed + 0.5f;
        }


        // KAMERA OYUNCUYA KÝTLÝ KODLARI
        //distancetoMove = player.transform.position.x - lastplayerPosition.x;
        //transform.position = new Vector3(transform.position.x + distancetoMove, transform.position.y, transform.position.z);
        //lastplayerPosition = player.transform.position;

    }
}
