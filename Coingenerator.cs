using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coingenerator : MonoBehaviour
{
    public Objectpooler coinPool;
    public float distancebetweenCoins;

    public void SpawnCoins(Vector3 Startposition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = Startposition;
        coin1.SetActive(true);
        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(Startposition.x + distancebetweenCoins, Startposition.y, Startposition.z);
        coin2.SetActive(true);
        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(Startposition.x - distancebetweenCoins, Startposition.y, Startposition.z);
        coin3.SetActive(true);
    }
    
}
