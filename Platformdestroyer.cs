using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformdestroyer : MonoBehaviour
{
    public GameObject platformdestructionPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        platformdestructionPoint = GameObject.Find("platformdestructionpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<platformdestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
            
        }
    }
}
