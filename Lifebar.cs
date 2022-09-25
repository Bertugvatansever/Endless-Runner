using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifebar : MonoBehaviour
{
    public GameObject lifeBar;
    public float health;
    private string ninjaHealth;
    private string playerHealth;


    private void Start()
    {
        ninjaHealth = PlayerPrefs.GetString("ninjaSelect");
        playerHealth = PlayerPrefs.GetString("playerSelect");
        if(ninjaHealth == "true")
        {
            health = 100;
        }
        else
        {
            health = 200;
        }
    }
    private void Update()
    {
        lifeBar.transform.localScale = new Vector3(health / 100, 1, 1);
       
    }

}
