using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterselector : MonoBehaviour
{
    public GameObject theNinja;
    public GameObject theplayer;
    public string ninjaSelect;
    public string playerSelect;
    // Start is called before the first frame update
   private void Awake()
    {
        ninjaSelect = PlayerPrefs.GetString("ninjaSelect");
        playerSelect = PlayerPrefs.GetString("playerSelect");
        if (ninjaSelect == "true")
        {
            theNinja.gameObject.SetActive(true);
        }
        else if (playerSelect == "true")
        {
            theplayer.gameObject.SetActive(true);
        }
    }
    
        
       

    // Update is called once per frame
    void Update()
    {
        
    }
}
