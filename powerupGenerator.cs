using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupGenerator : MonoBehaviour
{
    public GameObject Shield;
    public GameObject doublePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnShield(Vector3 powerupLocation)
    {
       
            GameObject powerup = Instantiate(Shield);
            powerup.transform.position = powerupLocation;
            powerup.SetActive(true);   
    }
    public void spawnDoublePoint(Vector3 powerup2Location)
    {
            GameObject powerup2 = Instantiate(doublePoint);
            powerup2.transform.position = powerup2Location;
            powerup2.SetActive(true);
    }
}
