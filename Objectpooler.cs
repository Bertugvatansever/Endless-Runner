using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;
    public List<GameObject> pooledObjects;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> pooledObjects = new List<GameObject>();
        for(int i=0;i<pooledAmount;i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        
    }

    // Update is called once per frame
    public GameObject GetPooledObject ()
    {
        for(int i=0;i<pooledObjects.Count;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;

    }
}
