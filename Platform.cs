using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float coinspawnPossibility;
    public Transform maxheightPoint;
    private EnemyGenerator enemyGenerator;
    private powerupGenerator powerupGenerator;
    public Objectpooler[] platformPool;
    private Coingenerator thecoingenerator;
    public Objectpooler[] theobjectPools;
    public Transform generationPoint;
    private Playercontrol powerupTime;
    public float distanceBetween;
    private float[] platformWidths;
    public float distancebetweenMin;
    public float distancebetweenMax;
    private int platformSelector;
    public float minHeight;
    public float maxHeight;
    private float heightchange;
    public float maxHeightChange;
    public float randomcoinSpawn;
    public float enemyspawnPossibility;
    public float powerupspawnPossibility;
    public int powerupSelect;
    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theobjectPools.Length];
        for(int i=0;i<theobjectPools.Length;i++)
        {
            platformWidths[i] = theobjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxheightPoint.position.y;
        thecoingenerator = FindObjectOfType<Coingenerator>();
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
        powerupGenerator = FindObjectOfType<powerupGenerator>();
        powerupTime = FindObjectOfType<Playercontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.transform.position.x)
        {
            powerupSelect = Random.Range(1,3);
            powerupspawnPossibility = Random.Range(0f, 100f);
            coinspawnPossibility = Random.Range(0f, 100f);
            distanceBetween = Random.Range(distancebetweenMin, distancebetweenMax);
            platformSelector = Random.Range(0, theobjectPools.Length);
            heightchange = transform.position.y + Random.Range(-maxHeightChange,maxHeightChange);
            if (heightchange>maxHeight)
            {
                heightchange = maxHeight;
            }
            else if(heightchange<minHeight)
            {
                heightchange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, heightchange, transform.position.z);
            GameObject newPlatform = theobjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            // altýn oluþturma ihtimali
            if(coinspawnPossibility <= randomcoinSpawn)
            {
              thecoingenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f));
            }
            else if(coinspawnPossibility > enemyspawnPossibility)
            {
                enemyGenerator.SpawnEnemy(new Vector3(transform.position.x, transform.position.y + 1.4f));
            }
            // powerup oluþturma ihtimali
            if(powerupspawnPossibility <= 10 && (powerupSelect == 1 && powerupTime.powerupactiveTime <=0))
            {
                powerupGenerator.SpawnShield(new Vector3(transform.position.x + distanceBetween, transform.position.y+3f));
            }
            if(powerupspawnPossibility <= 10 && (powerupSelect == 2 && powerupTime.powerupactiveTime2 <=0))
            {
                powerupGenerator.spawnDoublePoint(new Vector3(transform.position.x + distanceBetween, transform.position.y + 3f));
            }
        }
    }
}
